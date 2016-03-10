using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor
{
    public List<Room> rooms;

    // The current room. 0 = hallway, 1-3 = painting rooms.
    public int currentRoom = 0;
    public int previousRoom = 0;

    public string text;

    public Floor(List<Room> rooms, string text = "")
    {
        this.rooms = rooms;
        this.text = text;
    }

    public Room CurrentRoom
    {
        get
        {
            if (currentRoom > 0)
                return rooms[currentRoom - 1];
            else
                return null;
        }
    }

    public void ToRoom(int room)
    {
        previousRoom = currentRoom;
        currentRoom = room;

        if (room > 0)
        {
            // Mark room as visited.
            rooms[room - 1].visited = true;
        }
    }
}
