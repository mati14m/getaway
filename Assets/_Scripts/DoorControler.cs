using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{


    public GameObject nextDoor;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            other.gameObject.transform.position = nextDoor.transform.position-new Vector3(0,-1,-1);
    }
}
