using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string currentBuffer = "";
    public string crunchBuffer = "";
    public Ingredient currentIngredient;
    public bool completed = true;

    public IngredientEmitter emitter;

    public char[] allowedCharacter =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    };

    public TextLine uiText;

    // Start is called before the first frame update
    void Start()
    {
        nextIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if (Input.anyKeyDown)
            {
                string keyPressed = Input.inputString.ToLower();
                char[] characterArray = keyPressed.ToCharArray();
                if (characterArray.Length > 0)
                {
                    char character = keyPressed.ToCharArray()[0];

                    // check if input is allowed
                    if (allowedCharacter.Contains(character))
                    {
                        // check if input is correct
                        if (keyPressed == crunchBuffer.Substring(0, 1))
                        {
                            crunchBuffer = crunchBuffer.Remove(0, 1);
                            currentBuffer += keyPressed;
                            uiText.SetInputText(currentBuffer);


                            // if space, skip
                            if (crunchBuffer.Length > 0 && crunchBuffer.Substring(0, 1) == " ")
                            {
                                crunchBuffer = crunchBuffer.Remove(0, 1);
                                currentBuffer += " ";
                                uiText.SetInputText(currentBuffer);
                            }

                            if (crunchBuffer.Length == 0)
                            {
                                FinishIngredient();
                            }
                        };
                    }
                }
            }
        }
    }

    public void nextIngredient()
    {
        int random = Random.Range(0, IngredientsList.list.ingredients.Count - 1);
        currentIngredient = IngredientsList.list.Get(random);
        completed = false;
        uiText.SetBaseText(currentIngredient.GenerateName());
        crunchBuffer = currentIngredient.getGeneratedName();
    }

    public void FinishIngredient()
    {
        completed = true;
        uiText.ResetText();
        emitter.Emit(currentIngredient, emitter.transform.forward);

        crunchBuffer = "";
        currentBuffer = "";

        nextIngredient();
        
    }
}
