using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class picture : MonoBehaviour
{
    public string[] mes;
    public Sprite[] sprites;
    Image image;
    public TextMeshProUGUI textMesh;
    public int currentnum;
    public VideoPlayer player;
    public VideoClip[] clips;
    public GameObject video;
    void Start()
    {
        image = GetComponent<Image>();
        player = video.GetComponent<VideoPlayer>();
        video.SetActive(false);
        currentnum = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentnum--;
            if (currentnum >= sprites.Length)
            {
                player.Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentnum++;
            if (currentnum >= sprites.Length)
            {
                player.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MaterialHall");
        }

        if(currentnum < 0)
        {
            currentnum = sprites.Length+clips.Length-2;
        }
        if(currentnum >= sprites.Length)
        {
            video.SetActive(true);
        }
        if(currentnum > sprites.Length + clips.Length - 2)
        {
            currentnum = 0;
        }
        textMesh.text = "No."+(currentnum+1).ToString()+"  "+mes[currentnum];
        image.sprite = sprites[currentnum];

    }

}
