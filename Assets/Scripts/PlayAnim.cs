using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    Animator anim;
    public MenuCounter menuCounter;
    public float speed;
    public float distance;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    public void isUp()
    {
        anim.SetBool("isUp", true);
    }
}
