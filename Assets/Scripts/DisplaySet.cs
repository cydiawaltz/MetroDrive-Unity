using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DisplaySet : MonoBehaviour
{
    public float bairitu;
    public bool isSetWidth;
    public bool isSetHeight;
    /*private void Start()
    {
        isSetWidth = true;
        isSetHeight = false;
    }*/
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rectTransform = GetComponent<RectTransform>();//�Ώۂ̃I�u�W�F�N�g�ɃA�^�b�`
        float screenRatio = (float)width / height;
        //if (width/height > this.sprite.texture.width / this.sprite.texture.height)
        //{
        if (isSetWidth == true)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / bairitu);
        }
        if(isSetHeight == true)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / bairitu);
        }
        /*if(width/height<4/3)
        {
            test = true;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
        }*/
        //}
        /*if (width / height <= this.sprite.texture.width / this.sprite.texture.height)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / bairitu);
        }
        if(isFullScreenMode == true)
        {

        }*/
    }
}
