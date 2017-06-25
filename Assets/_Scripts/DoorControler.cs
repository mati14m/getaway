using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public int type; //1-N 2-E 3-S 4-W
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
        if (other.tag == "Player")
        {
			if(nextDoor.GetComponent<DoorControler>() == null) {
				Debug.Log ("NULL");
			}
            other.gameObject.transform.position = nextDoor.GetComponent<DoorControler>().getPlayerPosition();
        }
            

    }

    private Vector3 getPlayerPosition()
    {
        Vector3 vec;
        if (type == 1)
        {
            vec = transform.position - new Vector3(0, -1, 1);
        }
        else if (type == 2)
        {
            vec = transform.position - new Vector3(-1, -1, 0);
        }
        else if(type == 3)
        {
            vec = transform.position - new Vector3(0, -1, -1);
        }
        else
        {
            vec = transform.position - new Vector3(1, -1, 0);
        }
        return vec;
    }
}
