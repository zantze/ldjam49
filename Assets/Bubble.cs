using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    private float growSpeed = 0.05f;
    private float flySpeed = 0.45f;
    private float dt = 0;
    private bool popped = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().pitch = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {

        dt += Time.deltaTime;
        transform.Translate(transform.up * Time.deltaTime * flySpeed);

        Vector3 scale = transform.localScale;
        scale.x += growSpeed * Time.deltaTime;
        scale.y += growSpeed * Time.deltaTime;
        scale.z += growSpeed * Time.deltaTime;

        


        transform.localScale = scale;

        if (!popped && dt > 1.5f)
        {
            popped = true;
            GetComponent<AudioSource>().pitch = 1f;
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            
        }

        if (dt > 2f)
        {
            //Destroy(gameObject);
        }
    }
}
