using UnityEngine;
using System.Collections;

public class Painting : MonoBehaviour
{
    public string paintingName = "";
    public Renderer rend;

	void Start()
    {
        rend = GetComponent<Renderer>();

        if (paintingName == "")
        {
            paintingName = Museum.CurrentFloor.CurrentRoom.painting;
        }

        LoadMaterial();
        ScaleObject();
    }

    // Loads the painting material.
    void LoadMaterial()
    {
        if (paintingName != "")
        {
            Material material = Resources.Load("Materials/Paintings/" + paintingName, typeof(Material)) as Material;
            rend.material = material;
        }
    }

    // Scales the object according to the painting proportions.
    void ScaleObject()
    {
        // Get the proportions of the painting texture.
        Texture texture = rend.material.mainTexture;
        float paintingWidth = (float)texture.width;
        float paintingHeight = (float)texture.height;
        float proportions = paintingWidth / paintingHeight;

        // Scale the object.
        if (proportions > 1)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / proportions, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x * proportions, transform.localScale.y, transform.localScale.z);
    }
}
