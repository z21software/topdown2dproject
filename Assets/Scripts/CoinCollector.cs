using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCount;
    [SerializeField] private TextMeshProUGUI _dialogeText;
    [SerializeField] private GameObject _scorePopupPrefab;

    private int _score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameObject popup = Instantiate(_scorePopupPrefab, collision.transform.position, Quaternion.identity);
            popup.GetComponent<ScorePopup>().Initialize();
            _score++;
            UpdateUI();
            Destroy(collision.gameObject);
        }
            
    }

    private void UpdateUI()
    {
        _coinsCount.text = $"Очки: {_score}";
    }

    public void DecreaseScore(int damage)
    {
        if(_score == 0)
        {
            Destroy(gameObject);
        }
        _score = Mathf.Max(_score-damage, 0);
        UpdateUI();
    }
}

/*
 * [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private float _intervalSpawner = 5f;
    [SerializeField] private float _coinsCount = 3;
    private float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _intervalSpawner && _coinsCount != 0)
        {
            SpawnCoin();
            _timer = 0;
            _coinsCount--;
            Debug.Log($"Coins left: {_coinsCount}");
        }   
    }

    private void SpawnCoin()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-9.5f, 9.5f),
            Random.Range(-4.5f, 4.5f),
            0f
            );

        Instantiate(_coinPrefab, randomPosition, Quaternion.identity);
    }
 */
