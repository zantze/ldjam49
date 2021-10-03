using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{

    private float dt;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        Vector3 pos = originalPos;
        pos.y += Mathf.Sin(dt) * 0.3f;
        transform.position = pos;
    }
}
