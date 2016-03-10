using UnityEngine;
using System.Collections;

public class Overlay : MonoBehaviour
{
    public float animationTime = 1;
    public float t;

    protected Renderer rend;
    protected Function function;

    protected void Start()
    {
        rend = GetComponent<Renderer>();
        function = new WaveFunction();
    }
	
	void Update()
    {
        UpdateOverlay(function.Calc(t / animationTime));
        t += Time.deltaTime;
	}

    public virtual void UpdateOverlay(float val)
    {
        Color c = rend.material.color;
        c.a = val;
        rend.material.color = c;
    }
}
