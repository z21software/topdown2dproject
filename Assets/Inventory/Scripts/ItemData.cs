using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [Serializable] //for save system
    public class ItemData
    {
        public Item item;
        public bool isRotated = false;
        public Vector2Int matrixPosition; //bool[,]
        Vector3 slotPosition = Vector3.zero;
        //panelType
        public GameObject myLootContainer;
        public int myLootContainerId;   
    }
}
