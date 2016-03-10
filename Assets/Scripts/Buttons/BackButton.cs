using UnityEngine;
using System.Collections;

public class BackButton : Button
{
    void Start()
    {
        Load();

        nextScene = "Scenes/Hallway";
    }

    public override void OnNextScene()
    {
        Museum.ToRoom(0);
    }
}
