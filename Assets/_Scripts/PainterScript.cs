using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Generate paint decals
/// </summary>
public class PainterScript : MonoBehaviour
{
    public static PainterScript Instance;

    /// <summary>
    /// A single paint decal to instantiate
    /// </summary>
    public Transform PaintPrefab;
    public Camera camera;
    MouseLook mouseLook;

    void Start()
    {
        if (Instance != null) Debug.LogError("More than one Painter has been instanciated in this scene!");
        Instance = this;

        if (PaintPrefab == null) Debug.LogError("Missing Paint decal prefab!");
        mouseLook = GetComponentInParent<MouseLook>();
    }

    void Update()
    {
        // Check for a click
        if (Input.GetMouseButton(0)&&mouseLook.working)
        {
            // Raycast
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
            {
                var hitRotation = Quaternion.FromToRotation(Vector3.down, hit.normal);
                var tmp = Instantiate(PaintPrefab, hit.point, hitRotation);
                tmp.parent = hit.transform;
            }
        }
    }




}