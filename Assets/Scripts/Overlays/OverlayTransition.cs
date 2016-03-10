using UnityEngine;
using System.Collections;

public class OverlayTransition : Overlay {
	
	// Update is called once per frame
    public override void UpdateOverlay( float val)
    {
        rend.material.SetFloat("_Blend", val);
	}
}
