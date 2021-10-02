using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient 
{

    public string name;
    public string plural;
    public GameObject prefab;

    private string generatedName;

    public Ingredient()
    {

    }

    public string GenerateName()
    {
        string generated = name;
        // do generating magiks here
        // this will be the line that will be written
        generatedName = generated;
        return generated;
    }

    public string getGeneratedName()
    {
        return generatedName;
    }
}
