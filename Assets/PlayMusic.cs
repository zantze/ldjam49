using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public static PlayMusic current;

    public AudioSource aus;
    public AudioClip start;
    public AudioClip loop;

    private float dt = 0.0f;

    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        aus = GetComponent<AudioSource>();
        aus.clip = start;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((aus.time + dt) >= aus.clip.length )
        {
            aus.clip = loop;
            aus.Play();
        }
    }

    public void Play()
    {
        aus.Play();
    }

    
}
