using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpener : MonoBehaviour
{

    Animator animator;
    bool colision;
    public bool blocked;  
    bool open;
    public Canvas canvas;

    // Use this for initialization
    void Start()
    {
        colision = false;
        open = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")&&colision)
        {
            if (!blocked)
            {
                animator.SetTrigger("close");
                open = !open;
                changeText();
            }
            else
            {
                canvas.GetComponent<HUD>().setText("Locked");
            }
                
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("COLIDING");
            colision = true;
        }
        changeText();
        
    }

    private void OnTriggerExit(Collider other)
    {
        colision = false;
        canvas.GetComponent<HUD>().setText("");
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
    }

}
