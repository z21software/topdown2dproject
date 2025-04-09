using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEatable
{
    float GetHungerValue();
    void Consume();
}
