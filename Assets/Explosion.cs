using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Rigidbody[] bodies;
    public Rigidbody ceiling;
    private float dt = 0;
    private bool exploded = false;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;

        if (dt > 1 && !exploded)
        {
            ExplosionDamage(transform.position, 50);
            exploded = true;

            AudioSource[] sources = GetComponents<AudioSource>();
            foreach (AudioSource soossi in sources)
            {
                soossi.Play();
            }
        }

        if (dt > 3)
        {
            menu.SetActive(true);
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        ceiling.isKinematic = false;
        ceiling.AddForce(Vector3.up * 2000);

        foreach (Rigidbody body in bodies)
        {
            body.isKinematic = false;
            body.AddExplosionForce(800, center, 50);
        }
    }
}
