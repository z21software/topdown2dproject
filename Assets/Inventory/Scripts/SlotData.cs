using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class SlotData : MonoBehaviour, IDropHandler, IPointerEnterHandler
    {
        public Item.SlotType slotType;
        public Vector2Int matrixPosition;
        public PanelScript.Type panelType;
        public GameObject myLootContainer;
        public bool isFull = false; //for the character panel

        public void OnDrop(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }
    }
}

