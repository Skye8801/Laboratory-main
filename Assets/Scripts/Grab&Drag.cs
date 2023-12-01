using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDrag : MonoBehaviour
{

    private Camera cam;
    public float sensitivity = 3f;

    void Start()
    {
        cam = Camera.main;
    }

    private void OnMouseDrag()
    {
        float distanceToScreen = cam.WorldToScreenPoint(transform.position).z;

        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));

        float rotation = Input.mouseScrollDelta.y * sensitivity;
        transform.Rotate(Vector3.forward, rotation);


    }
}
