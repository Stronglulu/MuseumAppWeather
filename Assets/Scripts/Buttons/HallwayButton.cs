using UnityEngine;
using System.Collections;

public class HallwayButton : Button
{
    public int buttonIndex;

    void Start()
    {
        Load();

        Floor floor = Museum.CurrentFloor;

        // This button isn't needed.
        if (buttonIndex > floor.rooms.Count)
        {
            Destroy(transform.parent.gameObject);
        }
        // Assign correct scene.
        else
        {
            Room room = floor.rooms[buttonIndex - 1];
            nextScene = "Scenes/" + room.effect;

            GameObject icon = transform.Find("Icon").gameObject;
            Renderer iconRenderer = icon.GetComponent<Renderer>();
            iconRenderer.material = Resources.Load<Material>("Materials/Icon" + room.effect);

            if (room.visited)
            {
                GameObject checkmark = transform.parent.Find("Checkmark").gameObject;
                var checkmarkRenderer = checkmark.GetComponent<Renderer>();
                checkmarkRenderer.material = Resources.Load<Material>("Materials/Checkmark");
            }
        }
    }

    public override void OnNextScene()
    {
        Museum.ToRoom(buttonIndex);
    }

    public override bool IsActive()
    {
        // Tutorial floor unlocking.
        if (Museum.currentFloor == 1)
            for (int i = 0; i < buttonIndex - 1; i++)
                if (!Museum.CurrentFloor.rooms[i].visited)
                    return false;

        return base.IsActive();
    }
}
