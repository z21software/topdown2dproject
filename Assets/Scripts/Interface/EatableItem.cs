using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableItem : MonoBehaviour
{
    [Header("Settigns")]
    [SerializeField] private float _hungerRestoreValue = 2f;
    [SerializeField] private GameObject _consumeEffectPrefab;
    [SerializeField] private GameObject _scorePopupPrefab;

    public float GetHungerValue()
    {
        return _hungerRestoreValue;
    }

    public void Consume()
    {
        ConsumeEffect();
        Destroy(gameObject);
    }

    private void ConsumeEffect()
    {
        if (_consumeEffectPrefab != null)
        {
            Instantiate(
                _consumeEffectPrefab,
                transform.position,
                Quaternion.identity
            );
        }
        SpawnPopup(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            HungerStat playerHunger = collision.GetComponent<HungerStat>();
            playerHunger?.Increase(_hungerRestoreValue);
            Consume();
        }
    }

    private void SpawnPopup(Vector3 position)
    {
        if (_scorePopupPrefab == null) return;

        Instantiate(_scorePopupPrefab, position, Quaternion.identity);
    }
}
