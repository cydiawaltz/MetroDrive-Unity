using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class count : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public bool current;
    // Start is called before the first frame update
    void Start()
    {
        current = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            current = !current;
        }
        if(current)
        {
            first.SetActive(true);
            second.SetActive(false);
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("music");
            }
        }
        else
        {
            first.SetActive(false);
            second.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("picture");
        }
    }
}
