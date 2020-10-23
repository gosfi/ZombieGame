using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public static void restart()
    {
        string[] endings = new string[]{
         "exe", "x86", "x86_64", "app"
     };
        string executablePath = Application.dataPath + "/..";
        foreach (string file in System.IO.Directory.GetFiles(executablePath))
        {
            foreach (string ending in endings)
            {
                Debug.LogError(file.ToLower());
                if (file.ToLower().EndsWith("." + ending))
                {
                    System.Diagnostics.Process.Start(executablePath + file);
                    Application.Quit();
                    return;
                }
            }

        }
    }
}
