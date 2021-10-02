using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientObbo : MonoBehaviour
{
    private bool hasSplashed = false;
    private bool hasBonked = false;

    public AudioClip[] bonks;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        string othername = collision.contacts[0].otherCollider.gameObject.name; 
        if (othername == "cauldron" && !hasBonked)
        {
            hasBonked = true;
            AudioSource aus = this.GetComponent<AudioSource>();
            aus.clip = bonks[Random.Range(0, bonks.Length - 1)];
            aus.pitch = Random.Range(0.9f, 1.1f);
            aus.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Concotion conc = other.gameObject.GetComponent<Concotion>();
        if (conc != null)
        {
            conc.Splash(transform.position);
        }
    }
}
