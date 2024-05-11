using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FirstRunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstRun;
    public Save save;
    public bool isFirst;
    string path = ".. /SaveDeta/FirstBoot";
    private void Start()
    {
        /*if (File.Exists(path) == false)
        {
            isFirst = true;
        }
        else
        {
            isFirst = false;
        }*/
        if (File.Exists(path) == false) 
        {
            firstRun.SetActive(true);
            save.SaveFiles(path, "1");
            isFirst = false;
        }
        else 
        {
            firstRun.SetActive(false);
        }
    }
}
    /*void Start()
    {
        // firstRunというキーにデータがない場合
        if (!PlayerPrefs.HasKey("FirstRun"))
        {
            isFirst = true;
        }
        else
        {
            isFirst = false;
        }
        if (isFirst == true)
        {
            // 初回起動時の処理を実行
            FirstRun.SetActive(true);

            // FirstRunキーに値を入れる
            PlayerPrefs.SetInt("FirstRun", 1);
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("FirstRun") == 1)
            {
                FirstRun.SetActive(false);
            }
        }
    }
    private void Update()
    {
       if( PlayerPrefs.GetInt("FirstRun") == 0)
        {
            FirstRun.SetActive(true);
        }
    }
}
    */


