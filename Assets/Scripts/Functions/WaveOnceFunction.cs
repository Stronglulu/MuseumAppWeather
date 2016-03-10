using UnityEngine;
using System.Collections;
using System;

public class WaveOnceFunction : Function
{
    public override float Calc(float x)
    {
        return (float)Math.Cos(2 * Math.PI * Math.Min(x, 0.5)) / 2f + 0.5f;
    }
}
