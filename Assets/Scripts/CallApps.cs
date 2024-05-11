using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class CallApps : MonoBehaviour
{
    //ボタンにアタッチする
    public string appFileName;
    string exepath ;
    public void Start()
    {
        exepath = Path.Combine(Application.dataPath,"../Apps/"+appFileName);
    }
    
    public void OnClick()
    {
        Process.Start(exepath);
    }
}
