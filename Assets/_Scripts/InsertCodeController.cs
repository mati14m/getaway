using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertCodeController : MonoBehaviour {


    public InputField text1;
    public InputField text2;
    public InputField text3;
    public InputField text4;
    public Button button;
    string code;
    GameObject door;
    private Canvas canvas;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(checkCode);
        canvas = FindObjectOfType<Canvas>();
        transform.Find("View").gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		



	}

    private void checkCode()
    {
        string tmp = text1.text + text2.text + text3.text + text4.text;
        if (tmp.Equals(code))
        {
            canvas.GetComponent<HUD>().setText("Open");
            door.GetComponent<DoorOpener>().unlockDoor();
        }
        else
        {
            canvas.GetComponent<HUD>().setText("Locked");
        }
    }

    public void setCode(string code, GameObject door)
    {
        text1.text = "";
        text2.text = "";
        text3.text = "";
        text4.text = "";
        this.code = code;
        this.door = door;
    }
}
