using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class KabegamiSet : MonoBehaviour
{
    public bool isSetWidth;
    public bool isSetHeight;
    public float targetRatio;
    private void Start()
    {
        isSetWidth = true;
        isSetHeight = false;
    }
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rectTransform = GetComponent<RectTransform>();//対象のオブジェクトにアタッチ
        float screenRatio = (float)width / height;
        if(screenRatio <= targetRatio)
        {
            // 縦幅を解像度の縦幅に一致させる
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            // 横幅を縦幅とターゲット比率で設定
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, height * targetRatio);
        }
        else
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, width * targetRatio);
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
