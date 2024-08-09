using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public GameObject firstBoot;
    public GameObject waiting;
    public GameObject movie;
    public VideoPlayer videoPlayer;
    public string sceneName;
    public void Start()
    {
        videoPlayer = movie.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += FinishPlaying;
    }
    public void Update()
    {
        if(firstBoot.activeSelf == false && waiting.activeSelf == false)
        {
            movie.SetActive(true);
        }
        else
        {
            movie.SetActive(false);
        }
    }
    public void FinishPlaying(VideoPlayer vp)
    {
        vp = movie.GetComponent<VideoPlayer>();
        movie.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
