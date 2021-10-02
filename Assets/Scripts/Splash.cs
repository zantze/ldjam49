using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    private float up = 0.5f;
    private Vector3 original;
    private Vector3 direction;

    private float speed = 2.5f;
    private float yScale;
    private bool turned = false;

    public AudioClip[] splashes;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource aus = this.GetComponent<AudioSource>();
        aus.clip = splashes[Random.Range(0, splashes.Length - 1)];
        aus.pitch = Random.Range(0.9f, 1.1f);
        aus.Play();
        yScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (speed * Time.deltaTime));

        if (!turned && transform.localScale.z - yScale > up)
        {
            turned = true;
            speed = -speed;
        }

        if (turned && yScale - transform.localScale.z > up)
        {
            Destroy(gameObject);
        }
    }
}
