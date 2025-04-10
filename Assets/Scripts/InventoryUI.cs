using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Transform _slotsParent;
    [SerializeField] private PlayerInventory _inventory;

    private void Start()
    {
        // Подписка на событие
        _inventory.OnInventoryChanged += UpdateUI;
        UpdateUI(); // Первоначальное обновление
    }
    private void OnDestroy()
    {
        // Отписка при уничтожении
        _inventory.OnInventoryChanged -= UpdateUI;
    }
    public void UpdateUI()
    {
        Debug.Log("Updating UI...");
        foreach (Transform child in _slotsParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _inventory.slots.Count; i++)
        {
            InventorySlot slot = _inventory.slots[i];
            if (slot.item == null) continue; // Пропускаем пустые слоты

            GameObject slotObj = Instantiate(_slotPrefab, _slotsParent);
            slotObj.GetComponent<Image>().sprite = slot.item.icon;
            slotObj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString();

            int index = i;
            Button button = slotObj.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => _inventory.UseItem(index, FindObjectOfType<PlayerProperties>()));
            }
        }
    }
}
