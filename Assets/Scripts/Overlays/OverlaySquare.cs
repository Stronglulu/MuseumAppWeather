using UnityEngine;
using System.Collections;

public class OverlaySquare : OverlayCircle
{
    public override void UpdateOverlay(float val)
    {
        float xs = initialScale.x * (1f / (1 - val + 0.1f) / 1.5f);
        float ys = initialScale.y * (1f / (1 - val + 0.1f) / 1.5f);
        rend.material.mainTextureScale = new Vector2(xs, ys);
        rend.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
    }

    protected override void ScaleTexture()
    {
        initialScale = rend.material.mainTextureScale;
    }
}
