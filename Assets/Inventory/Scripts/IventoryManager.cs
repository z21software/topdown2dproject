using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Inventory
{
    public class IventoryManager : MonoBehaviour
    {
        #region SINGLETON
        private static IventoryManager instance = null;
        public static IventoryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("Game Manager").AddComponent<IventoryManager>();
                }
                return instance;
            }
        }

        private void OnEnable()
        {
            instance = this;
        }
        #endregion
        //slot
        [SerializeField] GameObject slotPrefab; //for instance
        [SerializeField] Transform slotParentBackpack;
        [SerializeField] Transform slotParentLoot;

        public Transform itemParentCharacter;
        public Transform itemParentBackpack;
        public Transform itemParentLoot;

        //Item UI prefabs
        [SerializeField] GameObject item1x1;
        [SerializeField] GameObject item1x2;
        [SerializeField] GameObject item1x3;
        [SerializeField] GameObject item1x4;
        [SerializeField] GameObject item1x5;
        [SerializeField] GameObject item2x2;
        [SerializeField] GameObject item3x3;
        
        //Dragging
        public bool isDraggingItem;
        public GameObject draggingItem;
        private float draggingItemSmoothFactor = 10f;
        public Transform draggingItemParent;
        //Color
        public Color agree;
        public Color disagree;
        //panel
        public List<PanelScript> panelList = new List<PanelScript>();
        //
        public bool isLockedUI;
        private Transform lastSlot;

        void Start()
        {
            panelList = GetComponents<PanelScript>().ToList();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator CreatePanel(PanelScript panel, LootData lootData)
        {
            ClearPanel(panel.type);

            if (lootData != null) //for lootdata and loot panel
            {
                panel.size = lootData.size;
            }

            yield return new WaitForEndOfFrame();

            for(int i = 0; i < panel.size.x; i++) //creating slots
            {
                for(int j = 0; j < panel.size.y; j++)
                {
                    GameObject slot = Instantiate(slotPrefab, panel.slotParent);
                    slot.transform.GetComponent<SlotData>().matrixPosition = new Vector2Int(i, j);
                    slot.transform.GetComponent<SlotData>().panelType = panel.type;
                    if(lootData != null)
                    {
                        slot.transform.GetComponent<SlotData>().myLootContainer = lootData.gameObject;
                    }
                }
            }
            yield return new WaitForEndOfFrame();

            panel.matrix = new bool[panel.size.x, panel.size.y];
            //Add items
            if (lootData != null)
            {
                FindSlotPositionForItem(panel.slotParent, lootData.itemList);
                panel.itemDataList = lootData.itemList; //list  synced
            }
            else
            {
                FindSlotPositionForItem(panel.slotParent, lootData.itemList);
            }
            FillItem(panel, lootData);
        }

        public void ClearPanel(PanelScript.Type panelType)
        {

        }

        public void FindSlotPositionForItem(Transform slotParent, List<ItemData> itemDataList)
        {
            foreach (ItemData itemData in itemDataList)
            {
                foreach (Transform slot in slotParent)
                {
                    if(slot.GetComponent<SlotData>().matrixPosition == itemData.matrixPosition)
                    {
                        itemData.slotPosition = slot.GetComponent<RectTransform>().position;
                        break;
                    }
                }
            }
        }

        public void FillItem(PanelScript panel, LootData lootData)
        {
            if(lootData != null) //for lootPanel
            {
                foreach(ItemData itemData in lootData.itemList)
                {
                    GameObject newItem = Instantiate(GetMyPrefab(itemData.item.slotSize), panel.itemParent);
                    newItem.transform.GetComponent<ItemDataMB>().itemData = itemData;
                    newItem.transform.GetComponent<ItemDataMB>().itemData.slotPanelType = panel.type;
                    newItem.transform.GetComponent<ItemUI>().Initialize();
                    SetMatrixThanPanel(itemData, true);
                }
            }
            else //pther panels
            {
                if (panel.type == PanelScript.Type.Backpack)
                {
                    foreach (ItemData itemData in lootData.itemList)
                    {
                        GameObject newItem = Instantiate(GetMyPrefab(itemData.item.slotSize), panel.itemParent);
                        newItem.transform.GetComponent<ItemDataMB>().itemData = itemData;
                        newItem.transform.GetComponent<ItemDataMB>().itemData.slotPanelType = panel.type;
                        newItem.transform.GetComponent<ItemUI>().Initialize();
                        SetMatrixThanPanel(itemData, true);
                    }
                }
                else if(panel.type == PanelScript.Type.Character)
                {
                    FindSlotPositionForItemCharacterPanel(panel.itemDataList);
                    foreach (ItemData itemData in lootData.itemList)
                    {
                        GameObject newItem = Instantiate(GetMyPrefab(itemData.item.slotSize), panel.itemParent);
                        newItem.transform.GetComponent<ItemDataMB>().itemData = itemData;
                        newItem.transform.GetComponent<ItemDataMB>().itemData.slotPanelType = panel.type;
                        newItem.transform.GetComponent<ItemUI>().Initialize();
                        SetMatrixThanPanel(itemData, true);
                    }
                }
            }
        }

        private GameObject GetMyPrefab(Vector2Int size)
        {
            if(size == new Vector2Int(1,1))
            {
                return item1x1;
            }
            else if (size == new Vector2Int(1, 2))
            {
                return item1x2;
            }
            else if (size == new Vector2Int(1, 3))
            {
                return item1x3;
            }
            else if (size == new Vector2Int(1, 4))
            {
                return item1x4;
            }
            else if (size == new Vector2Int(1, 5))
            {
                return item1x5;
            }
            else if (size == new Vector2Int(2, 2))
            {
                return item2x2;
            }
            else if (size == new Vector2Int(3, 3))
            {
                return item3x3;
            }
            return null;
        }

        private void SetMatrixThanPanel(ItemData itemData, bool value)
        {
            PanelScript panel = GetPanel(itemData.slotPanelType);
            Vector2Int itemSize = itemData.item.slotSize;

            //for character panel
            if (itemData.slotPanelType == PanelScript.Type.Character)
            {
                foreach(Transform slot in panel.slotParent)
                {
                    if(slot.GetComponent<SlotData>().matrixPosition.y == itemData.matrixPosition.y)
                    {
                        slot.GetComponent<SlotData>().isFull = value;
                        return;
                    }
                }
            }
            //end of character panel

            //for other panels
            if(!itemData.isRotated) //if no rotated
            {
                for (int i = 0; i < itemSize.x; i++)
                {
                    for (int j = 0; j < itemSize.y; j++)
                    {
                        panel.matrix[itemData.matrixPosition.x + i, itemData.matrixPosition.y + j] = value;
                    }
                }
            }
            else //if rotated
            {
                for (int i = 0; i < itemSize.y; i++)
                {
                    for (int j = 0; j < itemSize.x; j++)
                    {
                        panel.matrix[itemData.matrixPosition.x + i, itemData.matrixPosition.y + j] = value;
                    }
                }
            }
        }

        private void FindSlotPositionForItemCharacterPanel(List<ItemData> itemDataList)
        {
            PanelScript panel = GetPanel(PanelScript.Type.Character);
            foreach(ItemData itemData in itemDataList)
            {
                foreach(Transform slot in panel.slotParent)
                {
                    if(slot.GetComponent<SlotData>().matrixPosition.y == itemData.matrixPosition.y)
                    {
                        itemData.slotPosition = slot.GetComponent<RectTransform>().position;
                        break;
                    }
                }
            }
        }

        public PanelScript GetPanel(PanelScript.Type panelType)
        {
            foreach(PanelScript panel in panelList)
            {
                if(panel.type == panelType)
                {
                    return panel;
                }
            }
            return null;
        }
    }
}
