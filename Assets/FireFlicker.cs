using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlicker : MonoBehaviour
{

    private float dt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;

        if (dt > 0.1)
        {
            dt = 0;

            transform.Rotate(0, Random.Range(-10, 10), 0);
        }
    }
}
