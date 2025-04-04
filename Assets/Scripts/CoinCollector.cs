using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI _coinsCount;
    //[SerializeField] private TextMeshProUGUI _dialogeText;
    [SerializeField] private GameObject _scorePopupPrefab;

    [Header("Damage")]
    [SerializeField] private int _enemyDamage = 1;

    private int _score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Coin")) return;
        CollectCoin(collision.transform.position);
        Destroy(collision.gameObject);
    }

    private void CollectCoin(Vector3 position)
    {
        _score++;
        SpawnPopup(position);
        UpdateUI();
    }

    private void UpdateUI() => _coinsCount.text = $"Очки: {_score}";

    public void TakeDamage()
    {
        if (_score == 0) Destroy(gameObject);

        _score = Mathf.Max(_score - _enemyDamage, 0);
        UpdateUI();
    }

    private void SpawnPopup(Vector3 position)
    {
        if (_scorePopupPrefab == null) return;

        Instantiate(_scorePopupPrefab, position, Quaternion.identity)
            .GetComponent<ScorePopup>();
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
