using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDrinkable
{
    float GetDrinkValue();
    void Drink();
    float GetQuality();
    //bool isConsumable();
}
