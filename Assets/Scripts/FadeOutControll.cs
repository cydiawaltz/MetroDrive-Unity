using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutControll : MonoBehaviour
{
    public GameObject[] picture;
    public int num;
    public int max;
    private void Start()
    {
        num = Random.Range(1, max);
        picture[num].SetActive(true);
    }
    private void Update()
    {
        /*num++;
        if(num == 120)
        {
            picture1.GetComponent<FadeOut>().enabled = true;
        }
        if(num == 240)
        {
            picture2.GetComponent<FadeOut>().enabled = true;
        }
        if (num == 360)
        {
            picture3.GetComponent<FadeOut>().enabled = true;
        }*/
    }
}
