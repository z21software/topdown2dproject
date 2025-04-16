using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Inventory;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        #region SINGLETON
        private static UIController instance = null;
        public static UIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("Game Manager").AddComponent<UIController>();
                }
                return instance;
            }
        }

        private void OnEnable()
        {
            instance = this;
        }
        #endregion

        public CanvasGroup canvasGroupInventory;
        public CanvasGroup canvasGroupMenu;
        [SerializeField] GameObject lootPanel;

        public void SetCanvasInventory(bool value)
        {
            if (value) //if value is true
            {
                canvasGroupInventory.alpha = 1;
                canvasGroupInventory.interactable = true;
                canvasGroupInventory.blocksRaycasts = true;
            }
            else //if value is false
            {
                canvasGroupInventory.alpha = 0;
                canvasGroupInventory.interactable = false;
                canvasGroupInventory.blocksRaycasts = false;
            }
        }

        public void TurnCanvasInventory()
        {
            if(GetStatusOfCanvas(canvasGroupInventory))
            {
                canvasGroupInventory.alpha = 0;
                canvasGroupInventory.interactable = false;
                canvasGroupInventory.blocksRaycasts = false;
            }
            else 
            {
                canvasGroupInventory.alpha = 1;
                canvasGroupInventory.interactable = true;
                canvasGroupInventory.blocksRaycasts = true;
            }
        }

        public bool GetStatusOfCanvas(CanvasGroup canvasGroup)
        {
            if(canvasGroup.alpha == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetActiveLootPanel(bool value)
        {
            lootPanel.SetActive(value);
        }
    }
}
