using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
	void Start()
    {
        float angle = 180f - Museum.CurrentFloor.previousRoom * -90f;
        transform.Rotate(new Vector3(0, 1, 0), angle);
	}
}
