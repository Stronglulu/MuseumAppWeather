using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour
{
    public float fadeLength = 2;
    private Texture2D black;
    private float startTime;

	void Start()
    {
        black = Resources.Load<Texture2D>("Textures/Black");
        startTime = Time.time;
    }
	
	void Update()
    {
        if (Time.time - startTime >= fadeLength)
            Destroy(gameObject);
	}

    void OnGUI()
    {
        GUI.color = Color.black;

        Color c = GUI.color;
        c.a = Mathf.Lerp(1f, 0f, (Time.time - startTime));
        //Debug.Log(c.a);
        GUI.color = c;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), black);
    }
}
