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
        RectTransform rectTransform = GetComponent<RectTransform>();//�Ώۂ̃I�u�W�F�N�g�ɃA�^�b�`
        float screenRatio = (float)width / height;
        if(screenRatio <= targetRatio)
        {
            // �c�����𑜓x�̏c���Ɉ�v������
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            // �������c���ƃ^�[�Q�b�g�䗦�Őݒ�
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
