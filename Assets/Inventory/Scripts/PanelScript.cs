using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Inventory
{
    [Serializable]
    public class PanelScript : MonoBehaviour
    {
        public Type type;
        [Header("X: Row, Y: Column")] public Vector2Int size;
        public bool[,] matrix = new bool[1, 1];
        public List<GameObject> itemObjectList = new List<GameObject>();
        public List<ItemData> itemDetails = new List<ItemData>();
        public Transform slotParent;
        public Transform itemParent;

        public enum Type
        {
            Character,
            Backpack,
            Loot
        }
    }
}

