using UnityEngine;
using System.Collections;

public class HallwayText : MonoBehaviour
{
	void Start()
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        textMesh.text = Museum.CurrentFloor.text;
	}
}
