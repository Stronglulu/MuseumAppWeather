using UnityEngine;
using System.Collections;

public class CalibrationSquares : MonoBehaviour
{
	void Start()
    {
        if (Museum.currentFloor != 0)
            Destroy(gameObject);
	}
}
