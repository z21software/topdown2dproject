using UnityEngine;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject[] _coinsPrefabs;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterwal = 2.5f;
    [SerializeField] private int _maxSpawn = 5;
    [SerializeField] private float _gameDuration = 30;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _timer = 0;
    private int _remainingSpawns;

    private void Start()
    {
        _remainingSpawns = _maxSpawn;
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
        if(_timer >= _spawnInterwal && _remainingSpawns > 0)
        {
            SpawnRandomObjects();
            _timer = 0;
            _remainingSpawns--;
        }
    }

    private void SpawnRandomObjects()
    {
        bool shouldSpawnCoin = Random.value < .7f;
        Vector3 position = shouldSpawnCoin 
            ? GetRandomCoinPosition() 
            : GetRandomEnemyPosition();
        Instantiate(
            shouldSpawnCoin ? RandomCoinPrefab() : _enemyPrefab,
            position,
            Quaternion.identity
        );
    }

    private GameObject RandomCoinPrefab()
    {
        return _coinsPrefabs[Random.Range(0, _coinsPrefabs.Length)];
    }

    private Vector3 GetRandomEnemyPosition()
    {
        return new Vector3(
            Random.Range(-9.0f, 9.0f),
            Random.Range(-4.0f, 4.0f),
            0);
    }

    private Vector3 GetRandomCoinPosition()
    {
        return new Vector3(
            Random.Range(-9.0f, 9.0f),
            Random.Range(-4.0f, 4.0f),
            0);
    }

    private void UpdateGameTimer()
    {
        _gameDuration -= Time.deltaTime;
        _timerText.text = _gameDuration > 0
            ? $"Осталось {Mathf.FloorToInt(_gameDuration)}"
            : $"Время вышло =(";
    }
}
