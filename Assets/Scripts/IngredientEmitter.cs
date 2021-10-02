using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientEmitter : MonoBehaviour
{
    public GameObject fdd;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Emit(Ingredient ingredient, Vector3 direction)
    {
        GameObject prop = Instantiate(ingredient.prefab, transform.position, Quaternion.identity);
        prop.GetComponent<Rigidbody>().AddForce(direction * 500);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.2f);

        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 1;
        Gizmos.DrawRay(transform.position, direction);
    }
}
