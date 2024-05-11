using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    public GameObject firstRun;
    public CallApps callApps;
    public void OnClickCancel()
    {
        firstRun.SetActive(false);
    }
    
}
