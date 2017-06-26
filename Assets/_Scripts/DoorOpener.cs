using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpener : MonoBehaviour
{

    Animator animator;
    bool colision;
    bool blocked;  //dorobic blokowanie
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
            animator.SetTrigger("close");
            open = !open;
            changeText();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //dorobić wyświetlenie napisu
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

}
