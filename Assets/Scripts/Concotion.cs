using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concotion : MonoBehaviour
{
    public GameObject splash;
    public GameObject bubble;
    private float dt = 0f;
    private float nextBubble;

    // Start is called before the first frame update
    void Start()
    {
        nextBubble = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;

        if (dt > nextBubble)
        {
            dt = 0;
            nextBubble = Random.Range(1f, 3f);
            Vector3 pos = transform.position;
            pos.x += Random.Range(-0.3f, 0.3f);
            pos.z += Random.Range(-0.3f, 0.3f);
            Instantiate(bubble, pos, Quaternion.identity);
        }
    }

    public void Splash(Vector3 position)
    {
        Instantiate(splash, new Vector3(position.x, transform.position.y, position.z), Quaternion.Euler(new Vector3(-89.98f, 0,0)));    
    }

}
