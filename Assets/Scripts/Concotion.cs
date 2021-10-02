using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concotion : MonoBehaviour
{
    public GameObject splash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Splash(Vector3 position)
    {
        Instantiate(splash, new Vector3(position.x, transform.position.y, position.z), Quaternion.Euler(new Vector3(-89.98f, 0,0)));    
    }

}
