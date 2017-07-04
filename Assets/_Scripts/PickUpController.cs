using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    // Use this for initialization
    public GameObject tmp;
    IPickUpThing thing;

    Canvas canvas;
    bool colision;

    void Start () {
        canvas = FindObjectOfType<Canvas>();
        colision = false;
        if (tmp == null) Debug.LogError("Missing object ref");
        thing = tmp.GetComponent<IPickUpThing>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("f") && colision)
        {
            pickUp();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colision = true;
            canvas.GetComponent<HUD>().setText("Press F to pick up");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colision = false;
        canvas.GetComponent<HUD>().setText("");
    }

    void pickUp()
    {
        thing.pickUp();
        canvas.GetComponent<HUD>().setText("");
        Destroy(gameObject);
    }
}
