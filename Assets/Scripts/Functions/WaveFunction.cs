using UnityEngine;
using System.Collections;
using System;

public class WaveFunction : Function
{
    public override float Calc(float x)
    {
        return (float)Math.Cos(2 * Math.PI * x) / 2f + 0.5f;
    }
}
