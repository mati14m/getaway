using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Generate paint decals
/// </summary>
public class PainterScript : MonoBehaviour
{
    public static PainterScript Instance;
    public Transform PaintPrefab;
    public Camera camera;
    public Slider slider;
    public int capacity;
    public int maxCapacity;
    MouseLook mouseLook;

    void Start()
    {
        if (Instance != null) Debug.LogError("More than one Painter has been instanciated in this scene!");
        Instance = this;

        if (PaintPrefab == null) Debug.LogError("Missing Paint decal prefab!");
        mouseLook = GetComponentInParent<MouseLook>();
        slider.maxValue = maxCapacity;
        slider.value = capacity;
    }

    void Update()
    {
        // Check for a click
        if (Input.GetMouseButton(0)&&mouseLook.working&&capacity>0)
        {
            // Raycast
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
            {
                var hitRotation = Quaternion.FromToRotation(Vector3.down, hit.normal);
                var tmp = Instantiate(PaintPrefab, hit.point, hitRotation);
                tmp.parent = hit.transform;
                capacity--;
                slider.value = capacity;
            }
        }
    }


    public void setActive()
    {
        slider.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public void setUnactive()
    {
        slider.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void fillUpSpray()
    {
        slider.value = maxCapacity;
        capacity = maxCapacity;
    }

}