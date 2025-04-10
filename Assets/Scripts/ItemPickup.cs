using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private int _amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            bool success = other.GetComponent<PlayerInventory>().AddItem(_item, _amount);
            if (success) Destroy(gameObject);
        }
    }
}
