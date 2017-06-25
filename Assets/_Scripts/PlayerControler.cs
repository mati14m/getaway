using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float speed;
    private float x = 0, y = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        vertical *= speed;
        horizontal *= speed;

        transform.Translate(new Vector3(horizontal, 0F, vertical));

        var pos = transform.position;

        transform.position = new Vector3(pos.x , pos.y, pos.z);
        Camera mycam = GetComponent<Camera>();
        float sensitivity = 0.8f;

        Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x-x+mycam.pixelWidth/2, Input.mousePosition.y-y+ mycam.pixelHeight / 2, mycam.nearClipPlane));
        //Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        //Debug.Log(x + "  " + y);
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = mycam.ViewportToScreenPoint(vp);

        Vector3 v = mycam.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);

    }
}
