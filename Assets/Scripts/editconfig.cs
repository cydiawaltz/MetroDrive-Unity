using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class editconfig : MonoBehaviour
{
    string settingPath;//BVE‘¤
    string keepPath;
    string settingfilepath;//‚±‚Á‚¿‚ªUnity‘¤
    void Start()
    {
        settingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"BveTs\Settings\BveTs6.Preferences.xml");
        settingfilepath = Path.Combine(Application.dataPath, @"../SaveData\keep\BveTs6.Preferences.xml");
        keepPath = Path.Combine(Application.dataPath, @"../SaveData\config\normal.xml");
        if (File.Exists(settingPath))
        {
            File.Move(settingPath, keepPath);
        }
        File.Move(settingfilepath, settingPath);
    }
    private void OnApplicationQuit()
    {
        File.Move(settingPath, settingfilepath);
        if(File.Exists(keepPath))
        {
            File.Move(keepPath, settingPath);
        }
    }
}
