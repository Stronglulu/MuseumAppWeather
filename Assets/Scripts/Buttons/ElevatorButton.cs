using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElevatorButton : BackButton
{
    public override void OnNextScene()
    {
        Museum.ToRoom(0, false);
        Museum.ToNextFloor();
    }

    public override bool IsActive()
    {
        return base.IsActive() && Museum.CanContinue;
    }

    public override void Load()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        timer = 0;
        barBGMat = Resources.Load("Materials/elevatorBG") as Material;
        barSelectedMat = Resources.Load("Materials/elevatorSelected") as Material;
        barInactiveMat = Resources.Load("Materials/BarInactive") as Material;
        progressBar = transform.parent.FindChild("Bar Progress Pivot").gameObject;
        text = transform.parent.FindChild("Text").GetComponent<TextMesh>();
    }

}
