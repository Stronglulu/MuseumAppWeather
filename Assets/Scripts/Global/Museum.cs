using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class Museum
{
    public static List<Floor> floors;
    // The current floor (starts at 0).
    public static int currentFloor = 5;

    private static string logFilePath;

    public static void Load(string setupPath, string logPath)
    {
        string currentPath = getDataPath();

        floors = new List<Floor>();

        // Load museum.
        string setupNumber;
        string file = currentPath + setupPath;
        string line, hallwayText = "";
        using (StreamReader reader = new StreamReader(file))
        {
            List<Room> rooms = new List<Room>();

            // Setup number (first two lines).
            line = reader.ReadLine();
            setupNumber = line;
            reader.ReadLine();

            do
            {
                line = reader.ReadLine();

                if (line != null)
                {
                    string[] words = line.Split(' ');

                    // Empty line marks end of floor.
                    if (line.Length == 0)
                    {
                        floors.Add(new Floor(rooms, hallwayText));
                        rooms = new List<Room>();
                        hallwayText = "";
                    }
                    // Two words marks a room.
                    else if (words.Length == 2)
                        rooms.Add(new Room(words[0], words[1]));
                    else if (words.Length == 1)
                        hallwayText = HallwayText(words[0]);
                }
            }
            while (line != null);

            // Create logging file.
            logFilePath = currentPath + logPath;
            FileInfo f = new FileInfo(logFilePath);
            if (f.Exists)
                f.Delete();
            StreamWriter logger = f.CreateText();
            logger.WriteLine(setupNumber);
            logger.WriteLine();
            logger.WriteLine("t,event,fromFloor,toFloor,fromRoom,toRoom");
            logger.Close();
        }
    }

    private static string HallwayText(string roomType)
    {
        switch (roomType)
        {
            case "EMPTY":
                return "Please adjust your headset.";
            case "MIDDLE":
                return "Please take off your headset.";
            case "END":
                return "End of application.\nPlease take off your headset.";
            default:
                return "";
        }
    }

    public static string getDataPath()
    {
        if (Application.platform == RuntimePlatform.Android)
            return "/storage/emulated/0/SP/data";
        else
            return Application.persistentDataPath + "/data";
    }

    public static Floor CurrentFloor
    {
        get
        {
            return floors[currentFloor];
        }
    }

    // Returns true when all rooms have been visited.
    public static bool CanContinue
    {
        get
        {
            // Can't continue on last floor.
            if (currentFloor == floors.Count - 1)
                return false;
            foreach (Room room in CurrentFloor.rooms)
            {
                if (!room.visited)
                    return false;
            }
            return true;
        }
    }

    public static void ToRoom(int room, bool log = true)
    {
        int fromRoom = CurrentFloor.currentRoom;
        CurrentFloor.ToRoom(room);

        if (log)
            Log(Time.time, "to_room", currentFloor, currentFloor, fromRoom, room);
    }

    public static void ToNextFloor()
    {
        int fromFloor = currentFloor;
        int fromRoom = CurrentFloor.currentRoom;
        if (currentFloor < floors.Count - 1)
            currentFloor++;

        Log(Time.time, "next_floor", fromFloor, currentFloor, fromRoom, CurrentFloor.currentRoom);
    }

    public static void Log(float t, string ev, int fromFloor = -1, int toFloor = -1, int fromRoom = -1, int toRoom = -1)
    {
        LogPlain(
            t
            + "," + ev
            + "," + (fromFloor == -1 ? currentFloor : fromFloor)
            + "," + (toFloor == -1 ? currentFloor : toFloor)
            + "," + (fromRoom == -1 ? CurrentFloor.currentRoom : fromRoom)
            + "," + (toRoom == -1 ? CurrentFloor.currentRoom : toRoom)
            );
    }

    public static void LogPlain(string s)
    {
        StreamWriter logger = new StreamWriter(logFilePath, true);
        logger.WriteLine(s);
        logger.Close();
    }
}
