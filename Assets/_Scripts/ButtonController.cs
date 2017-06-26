using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public Canvas canvas;
    bool pushed;
    bool colision;
    public List<GameObject> doors;
    Animator animator;

    // Use this for initialization
    void Start () {
        pushed = false;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("f") && colision && !pushed)
        {
            animator.SetTrigger("pushed");
            unlockDoors();
            pushed = true;
            canvas.GetComponent<HUD>().setText("");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !pushed)
        {
            colision = true;
            writeText();
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        colision = false;
        canvas.GetComponent<HUD>().setText("");
    }

    private void writeText()
    {
        if(!pushed)
            canvas.GetComponent<HUD>().setText("Press F to push");
    }

    private void unlockDoors()
    {
        foreach(GameObject tmp in doors)
        {
            tmp.GetComponent<DoorOpener>().unlockDoor();
        }
    }

}
