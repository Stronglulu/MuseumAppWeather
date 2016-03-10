using UnityEngine;
using System.Collections;
using System;

public class OverlayCircle : Overlay
{
    protected Vector2 initialScale;

    new void Start()
    {
        rend = GetComponent<Renderer>();
        function = new WaveOnceFunction();

        ScaleTexture();
    }

    public override void UpdateOverlay(float val)
    {
        float xs = initialScale.x * (1f / (1 - val + 0.1f) / 2.2f);
        float ys = initialScale.y * (1f / (1 - val + 0.1f) / 2.2f);
        rend.material.mainTextureScale = new Vector2(xs, ys);
        rend.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
    }

    protected virtual void ScaleTexture()
    {
        Vector3 overlaySize = rend.bounds.size;
        float proportions = overlaySize.x / overlaySize.y;

        float xs, ys;
        if (proportions > 1)
        {
            xs = proportions;
            ys = 1;
        }
        else
        {
            xs = 1;
            ys = 1 / proportions;
        }

        // Scale and center the texture.
        rend.material.mainTextureScale = new Vector2(xs, ys);
        rend.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
        initialScale = rend.material.mainTextureScale;
    }
}
