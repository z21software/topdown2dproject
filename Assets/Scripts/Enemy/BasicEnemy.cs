using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private int _enemyDamage = 1;
    [SerializeField] private GameObject _scorePopupPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CoinCollector _coinCollector = FindObjectOfType<CoinCollector>();
            _coinCollector?.DecreaseScore(_enemyDamage);
            GameObject popup = Instantiate(_scorePopupPrefab, collision.transform.position, Quaternion.identity);
            popup.GetComponent<ScoreDecreasePopup>().Initialize();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Mathf.Sin(Time.time) * 2f * Time.deltaTime);
    }
}
