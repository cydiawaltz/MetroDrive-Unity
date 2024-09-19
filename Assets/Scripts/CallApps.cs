using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class CallApps : MonoBehaviour
{
    //ボタンにアタッチする
    public string appFileName;
    string exepath ;
    public ButtonControll buttonControll;
    public void Start()
    {
        exepath = Path.Combine(Application.dataPath,"../Apps/"+appFileName);
    }
    
    public void OnClick()
    {
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo(exepath)
        };
        process.EnableRaisingEvents = true;
        process.Exited += new System.EventHandler(Exited);
        process.Start();
    }
    void Exited(object sender,EventArgs e)
    {
        buttonControll.OnClickCancel();
    }
}
