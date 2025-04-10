using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStat
{
    void Increase(float value);
    void Decrease(float value);
}
