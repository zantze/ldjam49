using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    private Light light;
    private float originalBrightness;
    private float dt = 0f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        originalBrightness = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;

        if (dt > 0.1)
        {
            dt = 0;
            light.intensity = originalBrightness + Random.Range(-0.5f, 0.5f) ;
        }
    }
}
