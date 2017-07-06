using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpener : MonoBehaviour
{
    public bool needCode;
    public bool blocked;
    public string code;
    private InsertCodeController InsertCode;
    private AudioSource source;
    Animator animator;
    bool colision;
    public bool open;
    Canvas canvas;

    // Use this for initialization
    void Start()
    {
        colision = false;
        open = false;
        animator = GetComponent<Animator>();
        canvas = FindObjectOfType<Canvas>();
        source = GetComponent<AudioSource>();
        if (needCode)
        {
            InsertCode = GameObject.FindGameObjectWithTag("Code").GetComponent<InsertCodeController>();
            blocked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")&&colision)
        {
            keyDown();
                
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colision = true;
        }
        changeText();
    }

    private void OnTriggerExit(Collider other)
    {
        colision = false;
        canvas.GetComponent<HUD>().setText("");
        if (needCode)
        {
            InsertCode.setUnactive();
        }
    }

    private void changeText()
    {
        if (open)
        {
            canvas.GetComponent<HUD>().setText("Press F to close");
        }
        else
        {
            canvas.GetComponent<HUD>().setText("Press F to open");
        }
    }

    public void unlockDoor()
    {
        blocked = false;
        if (needCode)
        {
            InsertCode.setUnactive();
            needCode = false;
        }
    }

    private void keyDown()
    {
        if (blocked)
        {
            canvas.GetComponent<HUD>().setText("Locked");
            if (needCode)
            {
                InsertCode.setActive();
                InsertCode.setCode(code, gameObject);
            }
            blocked = true;
        }
        else
        {
            if (!needCode) 
            {
                animator.SetTrigger("close");
                open = !open;
                changeText();
                source.Play();
            }
        }
    }

}
