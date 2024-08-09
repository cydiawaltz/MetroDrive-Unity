using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    public GameObject firstRun;
    public GameObject waiting;
    public CallApps callApps;
    public void OnClickCancel()
    {
        waiting.SetActive(true);
        firstRun.SetActive(false);
    }
    public void OnClickEnd()
    {
        Application.Quit();
    }
}
