using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{
    [CreateAssetMenu(fileName = "SpecialName", menuName = "Item/New Special")]
    public class ItemSpecial : Item
    {
        [Header("Spacial Components")]
        public bool isEventItem;
    }
}


