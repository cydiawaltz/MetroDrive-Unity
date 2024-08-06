using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MenuCounter : MonoBehaviour
{
    public int currentNum;
    public int max;
    public bool isUp;
    public bool isDown;
    Animator anim;
    public GameObject mainCamera;
    public float speed;
    public float moveDist;
    Vector3 current;
    Vector3 Uptarget;
    Vector3 Downtarget;
    public GameObject[] backLight;
    float aspeed;
    void Start()
    {
        anim = mainCamera.GetComponent<Animator>();
        currentNum = 1;
        foreach (GameObject item in backLight)
        { item.SetActive(false); }
        backLight[currentNum].SetActive(true);
        //StartCoroutine()
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentNum++;
            if (currentNum == max + 1)
            {
                currentNum = 1;
                aspeed = speed * 3;
                isUp = true;
            }
            else { aspeed = speed; }
            //UpDownAnimater();
            //current += Vector3.down * speed * Time.deltaTime;
            //Down();
            foreach (GameObject item in backLight) 
            { item.SetActive(false); }
            backLight[currentNum].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentNum--;
            if (currentNum == 0)
            {
                currentNum = max;
                aspeed = speed * 3;
                isDown = false;
            }
            else { aspeed = speed; }
            //UpDownAnimater();
            //Up();
            foreach (GameObject item in backLight)
            { item.SetActive(false); }
            backLight[currentNum].SetActive(true);
        }
        Vector3 current = backLight[currentNum].transform.position;
        float movepos = Mathf.MoveTowards(mainCamera.transform.position.y, current.y-1.2f, aspeed * Time.deltaTime);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, movepos, mainCamera.transform.position.z);
    }
    public IEnumerator UpDownAnimater()
    {
        if(isUp == true)
        {
            anim.SetBool("isUp", true);//è„Ç…ÉXÉâÉCÉh
        }
        if(isDown == true) 
        {
            anim.SetBool("isDown", true);
        }
        yield return null;
    }
    /*public void Up()
    {
        mainCamera.transform.position = Vector3.MoveTowards(current, Uptarget, speed);
    }
    public void Down()
    {
        mainCamera.transform.position = Vector3.MoveTowards(current, Downtarget, speed);
    }*/
}
