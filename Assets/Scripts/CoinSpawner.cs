using UnityEngine;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject[] _coinsPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterwal = 2.5f;
    [SerializeField] private int _maxSpawns = 5;
    [SerializeField] private float _gameDuration = 30;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _timerText; 

    private float _timer = 0;
    private int _spawnRemaining;

    private void Start()
    {
        _spawnRemaining = _maxSpawns;
    }

    private void Update()
    {
        if (_gameDuration <= 0) return;
        HandleSpawn();
        UpdateGameTimer();
    }

    private void HandleSpawn()
    {
        _timer += Time.deltaTime;
        if(_timer >= _spawnInterwal && _spawnRemaining > 0)
        {
            SpawnRandomObject();
            _timer = 0;
            _spawnRemaining--;
        }
    }

    private void SpawnRandomObject()
    {
        bool shouldSpawnCoin = Random.value < .7f;
        bool enemySpawn = false;
        Vector3 position = shouldSpawnCoin ? GetRandomCoinPosition() : GetRandomEnemyPosition();

        Instantiate(
            shouldSpawnCoin ? GetRandomCoin() : _enemyPrefab,
            position,
            Quaternion.identity
        );
    }

    private GameObject GetRandomCoin()
    {
        return _coinsPrefab[Random.Range(0, _coinsPrefab.Length)];
    }

    private void UpdateGameTimer()
    {
        _gameDuration -= Time.deltaTime;
        _timerText.text = _gameDuration > 0
            ? $"Осталось {Mathf.FloorToInt(_gameDuration)} сек"
            : "Время вышло =(";
    }

    private static Vector3 GetRandomCoinPosition()
    {
        return new Vector3(
                    Random.Range(-9.5f, 9.5f),
                    Random.Range(-4.5f, 4.5f),
                    0f
                    );
    }

    private static Vector3 GetRandomEnemyPosition()
    {
        return new Vector3(
                    Random.Range(-5.5f, 5.5f),
                    Random.Range(-4f, 4f),
                    0f
                    );
    }
}
