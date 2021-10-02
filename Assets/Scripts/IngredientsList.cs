using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsList : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Ingredient> ingredients = new List<Ingredient>();
    public static IngredientsList list;

    private void Awake()
    {
        list = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Ingredient Get(int id)
    {
        return ingredients[id];
    } 
}
