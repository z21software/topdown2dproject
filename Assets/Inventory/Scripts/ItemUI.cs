using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemUI : MonoBehaviour
    {
        private ItemData itemData;
        //*Backup
        private Vector3 startPosition;
        private bool startRotate;
        private Transform startParent;
        private Vector2Int startItemMatrixPosition;
        //Backup*
        public void Initialize()
        {
            itemData = GetComponent<ItemDataMB>().itemData;
            transform.GetChild(0).GetComponent<Image>().color = itemData.item.backgroundColor;
            transform.GetChild(0).GetChild(0).transform.GetComponent<Image>().sprite = itemData.item.image;
            transform.GetComponent<RectTransform>().position = itemData.slotPosition;

            if (transform.childCount > 1)
            {
                transform.GetChild(1).GetComponent<Image>().color = itemData.item.backgroundColor;
                transform.GetChild(1).GetChild(0).transform.GetComponent<Image>().sprite = itemData.item.image;
                
                if(itemData.isRotated)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
}

