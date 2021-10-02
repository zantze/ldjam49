using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient
{

    enum Difficulty {
    BEGINNER, EASY, MEDIUM, HARD }

    public string name;
    public string plural;
    public GameObject prefab;

    private int amount;

    private string generatedName;

    public Ingredient()
    {

    }

    public string GenerateName(int difficulty = 0)
    {
        string generated = "";
        // do generating magiks here
        // this will be the line that will be written
        switch(difficulty)
        {
            case 0:
                generateAmount(Difficulty.BEGINNER);
                break;
            case 1:
                generated += generateModifier(Difficulty.EASY);
                generated += " ";
                break;
            case 2:
                generated += generateModifier(Difficulty.MEDIUM);
                generated += " ";
                break;
            case 3:
                generated += generateAmount(Difficulty.EASY);
                generated += " ";
                generated += generateModifier(Difficulty.EASY);
                generated += " ";
                break;
            case 4:
                generated += generateAmount(Difficulty.EASY);
                generated += " ";
                generated += generateModifier(Difficulty.MEDIUM);
                generated += " ";
                break;
            case 5:
                generated += generateAmount(Difficulty.MEDIUM);
                generated += " ";
                generated += generateModifier(Difficulty.MEDIUM);
                generated += " ";
                break;
            case 6:
                generated += generateAmount(Difficulty.HARD);
                generated += " ";
                generated += generateModifier(Difficulty.MEDIUM);
                generated += " ";
                break;
            case 7:
                generated += generateAmount(Difficulty.HARD);
                generated += " ";
                generated += generateModifier(Difficulty.HARD);
                generated += " ";
                break;
            default:
                generated += generateAmount(Difficulty.HARD);
                generated += " ";
                generated += generateModifier(Difficulty.HARD);
                generated += " ";
                break;

        }

        if (amount > 1)
            generated += plural;
        else
            generated += name;

        generatedName = generated;
        return generated;
    }

    private string generateAmount(Difficulty diff)
    {
        int i = 0;

        switch (diff)
        {
            case Difficulty.BEGINNER:
                i = 0;
                break;
            case Difficulty.EASY:
                i = Random.Range(1, 6);
                break;
            case Difficulty.MEDIUM:
                i = Random.Range(1, 12);
                break;
            case Difficulty.HARD:
                i = Random.Range(1, 24);
                break;
        }

        this.amount = i;

        return NumberStringGenerator.getNumberAsString(i);
    }

    private string generateModifier(Difficulty diff)
    {
        string modifier = "";

        switch (diff)
        {
            case Difficulty.BEGINNER:
                modifier = "";
                break;
            case Difficulty.EASY:
                modifier = Adjective.PickRandom(Adjective.easyAdjectives);
                break;
            case Difficulty.MEDIUM:
                modifier = Adjective.PickRandom(Adjective.mediumAdjectives);
                break;
            case Difficulty.HARD:
                modifier = Adjective.PickRandom(Adjective.hardAdjectives);
                break;
        }

        return modifier;
    }

    public string getGeneratedName()
    {
        return generatedName;
    }

    public int getAmount()
    {
        return amount;
    }
}

public class Adjective
{
    public static string[] easyAdjectives =
    {
        "fast",
        "bad",
        "gross",
        "nice",
        "funny",
        "odd"
    };

    public static string[] mediumAdjectives =
    {
        "tubular",
        "extreme",
        "overgrown",
        "bubbling",
    };

    public static string[] hardAdjectives =
    {
        "peculiar",
        "enormous",
        "beautiful",
        "expensive",
        "luxurious",
        "nastiest",
        "stupendous"
    };

    public static string PickRandom(string[] list)
    {
        return list[Random.Range(0, list.Length - 1)];
    }
}

public class NumberStringGenerator
{
    public static string getNumberAsString(int i)
    {
        switch (i)
        {
            case 0: return "";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            case 10: return "ten";
            case 11: return "eleven";
            case 12: return "twelve";
            case 13: return "thirteen";
            case 14: return "fourteen";
            case 15: return "fifteen";
            case 16: return "sixteen";
            case 17: return "seventeen";
            case 18: return "eighteen";
            case 19: return "nineteen";
            case 20: return "twenty";
            case 21: return "twentyone";
            case 22: return "twentytwo";
            case 23: return "twentythree";
            case 24: return "twentyfour";
            default: return "";
        }
    }
}