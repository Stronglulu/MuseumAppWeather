using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class DebugText : MonoBehaviour
{
    TextMesh textMesh;

	void Start()
    {
        textMesh = GetComponent<TextMesh>();

        string currentPath = Museum.getDataPath();

        //StreamWriter w;
        //FileInfo f = new FileInfo(currentPath + "/test.txt");
        //if (f.Exists)
        //    f.Delete();
        //w = f.CreateText();
        //w.WriteLine("Test...");
        //w.Close();

        StreamReader reader = new StreamReader(currentPath + "/setup.txt", Encoding.Default);
        using (reader)
        {
            textMesh.text = reader.ReadToEnd();
        }
	}
}
