using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    public AudioClip[] whooshes;

    public string currentBuffer = "";
    public string crunchBuffer = "";
    public Ingredient currentIngredient;
    public bool completed = true;

    public IngredientEmitter emitter;
    private List<Ingredient> ingredientsToSpawn = new List<Ingredient>();

    public char[] allowedCharacter =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    };

    public TextLine uiText;
    public Text uiTimer;
    public Text uiScore;

    public float timePerText = 8f;
    public float currentTime = 0f;

    public int difficulty = 0;

    public int score = 0;

    public float difficultyTimer = 0f;
    public float spawnTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        difficultyTimer += Time.deltaTime;
        uiScore.text = "" + score;
        spawnTimer += Time.deltaTime;

        if (ingredientsToSpawn.Count > 0 && spawnTimer > 0.15f)
        {
            spawnTimer = 0;
            Emit(ingredientsToSpawn[0]);
            ingredientsToSpawn.RemoveAt(0);

        }


        if (difficultyTimer > 20f)
        {
            difficulty++;
            difficultyTimer = 0;
        }


        if (!completed)
        {
            currentTime += Time.deltaTime;
            uiTimer.text = "" + (timePerText -  currentTime);

            if (timePerText - currentTime < 0)
            {
                Debug.Log("Lost game");
                // do game loss mechanics
            }

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
        currentTime = 0;
        int random = Random.Range(0, IngredientsList.list.ingredients.Count - 1);
        currentIngredient = IngredientsList.list.Get(random);
        completed = false;
        uiText.SetBaseText(currentIngredient.GenerateName(difficulty));
        crunchBuffer = currentIngredient.getGeneratedName();
    }

    public void FinishIngredient()
    {
        completed = true;

        uiTimer.text = "";

        uiText.ResetText();

        int amount = currentIngredient.getAmount();
        if (amount == 0) amount = 1;
        for (int i = 0; i < amount; i++)
        {
            ingredientsToSpawn.Add(currentIngredient);
        }
        
        
        crunchBuffer = "";
        currentBuffer = "";

        score += 100 + (20 * difficulty);

        AudioSource aus = mainCamera.GetComponent<AudioSource>();
        aus.clip = whooshes[Random.Range(0, whooshes.Length - 1)];
        aus.pitch = Random.Range(0.9f, 1.1f);
        aus.Play();

        nextIngredient();
        
    }

    private void Emit(Ingredient ing)
    {
        emitter.Emit(ing, emitter.transform.forward);
    }
}
