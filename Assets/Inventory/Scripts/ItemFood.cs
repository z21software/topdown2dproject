using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "FoodName", menuName = "Item/New Food")]
    public class ItemFood : Item
    {
        [Header("Food Components")]
        public FoodType foodType;
        public int hunger;
        public int thirsty;
        public enum FoodType
        {
            Food,
            Drink
        }
    }
}

