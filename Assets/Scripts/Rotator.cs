using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float speed = 1.0f;
    public bool rotateYaw = false;
    public bool zoomCamera = false;
    private Camera cam;
    private float originalFov;
    public float td = 0.0f;
    private float td2 = 0.0f;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        if (zoomCamera)
        {
            cam = child.GetComponent<Camera>();
            originalFov = cam.fieldOfView;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30 * speed) * Time.deltaTime);
        
        if (rotateYaw)
        {
            td += Time.deltaTime * 0.33f;
            child.transform.Rotate(new Vector3(Mathf.Sin(td), 0, 0) * Time.deltaTime);
        }

        if (zoomCamera)
        {
            td2 += Time.deltaTime * 0.62f;
            cam.fieldOfView = originalFov + Mathf.Sin(td) * 3 + Mathf.Sin(td2) * 3;
        }
    }
}
