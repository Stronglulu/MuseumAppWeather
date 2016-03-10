using UnityEngine;
using System.Collections;

public class Decoration : MonoBehaviour {

    GameObject child;

	// Use this for initialization
	void Start () {
        Debug.Log("Floor: " + Museum.currentFloor);
        child = transform.FindChild("Floor" + (Museum.currentFloor)).gameObject;
        child.SetActive(true);
        //Debug.Log("Floor: "+ Museum.currentFloor);
        Debug.Log(child);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
