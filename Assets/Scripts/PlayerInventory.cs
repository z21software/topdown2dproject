using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _maxSlots = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public event Action OnInventoryChanged;

    public bool AddItem(Item item, int amount = 1)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item && slot.amount < item.maxStack)
            {
                slot.AddAmount(amount);
                OnInventoryChanged?.Invoke();
                return true;
            }
        }

        if (slots.Count < _maxSlots)
        {
            slots.Add(new InventorySlot(item, amount));
            OnInventoryChanged?.Invoke();
            return true;
        }

        Debug.Log("Inventory full!");
        return false; // Возвращаем false, если инвентарь полон
    }

    public void UseItem(int slotIndex, PlayerProperties player)
    {
        if (slotIndex < 0 || slotIndex >= slots.Count) return;

        InventorySlot slot = slots[slotIndex];
        if (slot.item.isConsumable)
        {
            slot.item.Use(player);
            slot.amount--;
            if (slot.amount <= 0) slots.RemoveAt(slotIndex);
            OnInventoryChanged?.Invoke(); // И здесь при использовании
        }
    }
}
