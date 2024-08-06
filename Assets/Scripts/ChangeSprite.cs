using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public MenuCounter menuCounter;
    public int currentNum;
    Image image;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentNum = menuCounter.currentNum;
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            image.sprite = sprites[currentNum];
        }
    }
}
