using UnityEngine;
using System.Collections;

public class FloorText : MonoBehaviour
{
	void Start()
    {
        if (Museum.CurrentFloor.rooms.Count > 0)
        {
            int floor = 0;
            for (int i = 0; i < Museum.currentFloor; i++)
            {
                if (Museum.floors[i].rooms.Count > 0)
                    floor++;
            }
            TextMesh textMesh = GetComponent<TextMesh>();
            textMesh.text = floor.ToString();
        }
	}
}
