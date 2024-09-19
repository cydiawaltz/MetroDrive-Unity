using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EnterOther : MonoBehaviour
{
    public string sceneName1;
    public string sceneName2;
    public string sceneName3;
    public string sceneName4;
    public string sceneName5;
    public MenuCounter counter;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(counter.currentNum == 1)
            {
                SceneManager.LoadScene(sceneName1);
            }
            if(counter.currentNum == 2)
            {
                SceneManager.LoadScene(sceneName2);
            }
            if(counter.currentNum == 3)
            {
                SceneManager.LoadScene(sceneName3);
            }
            if( counter.currentNum == 4)
            {
                SceneManager.LoadScene(sceneName4);
            }
            if(counter.currentNum == 5)
            { 
                try
                {
                    Process process = new Process();
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = Path.Combine(Application.dataPath, "../../../HongoMCCGame2024.exe"),
                    };
                    process.Start();
                }
                finally
                {
                    Application.Quit();
                }
            }
        }
    }
}
