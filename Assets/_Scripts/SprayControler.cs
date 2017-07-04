using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayControler : MonoBehaviour, IPickUpThing
{

    
    public bool startWithSpray;
    PainterScript spray;
    // Use this for initialization
    void Start () {
        spray = GetComponentInChildren<PainterScript>();
        if (!startWithSpray)
        {
            spray.setUnactive();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    new public void pickUp()
    {
        spray.setActive();
        spray.fillUpSpray();
    }
}
