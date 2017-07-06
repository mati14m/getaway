using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public string gameplayLevelName;
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
        if (collision.gameObject.tag == "Player" && doorOpener.open)
        {
            SceneManager.LoadScene(gameplayLevelName);
        }
    }
}
