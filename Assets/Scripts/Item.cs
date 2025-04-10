using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "Item";
    public Sprite icon = null;
    public int maxStack = 1;
    public bool isConsumable = false;

    public virtual void Use(PlayerProperties player)
    {
        Debug.Log($"Use {itemName}");
    }
}
