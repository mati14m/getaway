using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControler : MonoBehaviour
{
    public int type; //1-N 2-E 3-S 4-W
    public GameObject nextDoor;
    public DoorOpener doorOpener;
    // Use this for initialization
    void Start()
    {
        doorOpener = GetComponentInParent<DoorOpener>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&doorOpener.open)
        {
            if (nextDoor.GetComponent<PortalControler>() == null)
            {
                Debug.Log("NULL");
            }
            collision.gameObject.transform.position = nextDoor.GetComponent<PortalControler>().getPlayerPosition();
            collision.gameObject.transform.LookAt(nextDoor.transform);
            collision.gameObject.transform.Rotate(0,180,0);
        }
    }


    private Vector3 getPlayerPosition()
    {
        Vector3 vec;
        if (type == 1)
        {
            vec = transform.position - new Vector3(0, 0, 1);
        }
        else if (type == 2)
        {
            vec = transform.position - new Vector3(1, 0, 0); 
        }
        else if(type == 3)
        {
            vec = transform.position - new Vector3(0, 0, -1);
        }
        else
        {
            vec = transform.position - new Vector3(-1, 0, 0);
        }
        return vec;
    }
}
