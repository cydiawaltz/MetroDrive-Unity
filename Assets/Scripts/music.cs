using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    public AudioClip[] audioClip;
    public string[] mes;
    AudioSource audioSource;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI explain;
    public int currentnum;
    public int max;
    bool ischange;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentnum = 0;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MaterialHall");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentnum--;
            ischange = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentnum++;
            ischange = true;
        }
        if (currentnum < 0)
        {
            currentnum = max;
        }
        if (currentnum > max)
        {
            currentnum = 0;
        }
        if(ischange)
        {
            explain.text = mes[currentnum];
            audioSource.Stop();
            audioSource.clip = audioClip[currentnum];
            audioSource.Play();
            ischange = false;
        }
        if(currentnum < 10)
        {
            textMeshProUGUI.text = "Track:0"+(currentnum).ToString();
        }
        else
        {
            textMeshProUGUI.text = "Track:"+(currentnum).ToString();
        }
    }
}
