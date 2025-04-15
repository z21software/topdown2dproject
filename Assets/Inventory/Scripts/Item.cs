using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public abstract class Item : ScriptableObject
    {
        [Header("Main Item COmponents")]
        public string itemName;
        [Multiline] public string description;
        public int id;
        public ItemType type;
        public SlotType slotType;
        public Frequency frequency;
        public Vector2Int slotSize;
        public Sprite image;
        public Color backgroundColor;
        public GameObject prefab;


        //usefull to get rid of magic numbers
        public enum ItemType
        {
            Weapon,
            Food,
            Cloth,
            Money,
            Ammo,
            Magazine,
            Special
        }

        //if slot type == headset, player can't drag there knife
        public enum SlotType
        {
            General,
            Headset,
            Headwear,
            FaceCover,
            TacticalRig,
            BodyArmor,
            Backpack,
            Pistol,
            Knife,
            Weapon
        }

        //for spawn manager. spawn items depends on it's frequency
        public enum Frequency
        {
            one = 1,
            five = 5,
            ten = 10,
            twenty_five = 25,
            fifty = 50
        }
    }
}

