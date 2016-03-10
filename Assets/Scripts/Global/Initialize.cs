using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class Initialize : MonoBehaviour
{
    string logPath = "/log1.csv";
    string dataPath;
    int logNr = 1;

	void Start()
    {
        dataPath = Museum.getDataPath();

        // Loop through existing files until one cannot be found.
        while (File.Exists(dataPath + logPath))
        {
            logNr++;
            logPath = "/log" + (logNr) + ".csv";
        }

        Museum.Load("/setup.txt", logPath);
        SceneManager.LoadScene("Scenes/Hallway");
    }
}
