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
        UpdateTimerUI();
    }

    private void Update()
    {
        UpdateTimerUI();
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterwal && _maxSpawns != 0)
        {
            SpawnPrefabs();
        }
    }

    private void SpawnPrefabs()
    {
        float num = Random.value;
        if (num < .7f)
        {
            SpawnCoin();
        }
        else
        {
            SpawnEnemy();
        }
        _timer = 0;
        _maxSpawns--;
        Debug.Log($"Coins left to spawn: {_maxSpawns}");
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, GetEnemyRandomPosition(), Quaternion.identity);
    }

    private void UpdateTimerUI()
    {
        _gameDuration -= Time.deltaTime;
        int timeConvertToInt = Mathf.FloorToInt(_gameDuration);
        _timerText.text = $"Осталось {timeConvertToInt} сек";
        if(_gameDuration <= 0)
        {
            _timerText.text = $"Время вышло =(";
        }
    }

    private void SpawnCoin()
    {
        Vector3 randomPosition = GetCoinRandomPosition();
        int coinIndex = Random.Range(0, _coinsPrefab.Length);
        GameObject coin = Instantiate(_coinsPrefab[coinIndex], randomPosition, Quaternion.identity);
        coin.transform.localScale = Vector3.zero;
        coin.AddComponent<CoinAnimation>();
    }

    private static Vector3 GetCoinRandomPosition()
    {
        return new Vector3(
                    Random.Range(-9.5f, 9.5f),
                    Random.Range(-4.5f, 4.5f),
                    0f
                    );
    }

    private static Vector3 GetEnemyRandomPosition()
    {
        return new Vector3(
                    Random.Range(-5.5f, 5.5f),
                    Random.Range(-4f, 4f),
                    0f
                    );
    }
}
