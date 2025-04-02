using UnityEngine;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _coinsPrefab;
    [SerializeField] private float _spawnInterwal = 2.5f;
    [SerializeField] private int _toSpawnLeft = 3;
    [SerializeField] private float _globalTimer = 30;
    [SerializeField] private TextMeshProUGUI _timerText; 
    private float _timer = 0;

    private void Update()
    {
        UpdateTimerUI();
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterwal && _toSpawnLeft != 0)
        {
            SpawnCoin();
            _timer = 0;
            _toSpawnLeft--;
            Debug.Log($"Coins left to spawn: {_toSpawnLeft}");
        }
    }

    private void UpdateTimerUI()
    {
        _globalTimer -= Time.deltaTime;
        int timeConvertToInt = Mathf.FloorToInt(_globalTimer);
        _timerText.text = $"Осталось {timeConvertToInt} сек";
        if(_globalTimer <= 0)
        {
            _timerText.text = $"Время вышло =(";
        }
    }

    private void SpawnCoin()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-9.5f, 9.5f),
            Random.Range(-4.5f, 4.5f),
            0f
            );

        int coinIndex = Random.Range(0, _coinsPrefab.Length);
        GameObject coin = Instantiate(_coinsPrefab[coinIndex], randomPosition, Quaternion.identity);
        coin.transform.localScale = Vector3.zero;
        coin.AddComponent<CoinAnimation>();
    }
}
