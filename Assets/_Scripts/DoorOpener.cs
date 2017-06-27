using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpener : MonoBehaviour
{
    public bool needCode;
    public bool blocked;
    public string code;
    private GameObject InsertCode;
    Animator animator;
    bool colision;
    bool open;
    Canvas canvas;

    // Use this for initialization
    void Start()
    {
        colision = false;
        open = false;
        animator = GetComponent<Animator>();
        canvas = FindObjectOfType<Canvas>();
        if (needCode)
        {
            InsertCode = GameObject.FindGameObjectWithTag("Code");
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
            InsertCode.transform.Find("View").gameObject.SetActive(false);
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
            InsertCode.transform.Find("View").gameObject.SetActive(false);
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
                InsertCode.transform.Find("View").gameObject.SetActive(true);
                InsertCode.GetComponent<InsertCodeController>().setCode(code, gameObject);
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
            }
        }
    }

}
