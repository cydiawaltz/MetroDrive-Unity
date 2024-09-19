using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MovieWait : MonoBehaviour
{
    VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += Exited;
    }

    void Exited(VideoPlayer vp)
    {
        SceneManager.LoadScene("Main");
    }
}
