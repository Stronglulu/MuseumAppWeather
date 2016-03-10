using UnityEngine;
using System.Collections;

public class LoadStylizedMaterial : MonoBehaviour {

    private Renderer rend;
    private bool loaded = false;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        LoadMaterial();
	}
    
    // Loads the extension material.
    void LoadMaterial()
    {
        // Use the name of the painting.
        string paintingName = Museum.CurrentFloor.CurrentRoom.painting;
        if (paintingName != "")
        {
            Material material = Resources.Load("Materials/Illusions/Stylized/" + paintingName, typeof(Material)) as Material;
            rend.material = material;
        }
    }
}
