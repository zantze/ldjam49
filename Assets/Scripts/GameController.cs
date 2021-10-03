using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public RectMask2D uiMeterMask;
    private float uiMeterMaskMax = 277f;
    private float uiMeterMultiplier = 0f;

    private float timePerText;
    public float timePerTextHard = 7.3f;
    public float timePerTextEasy = 12f;
    public float currentTime = 0f;

    public int difficulty = 0;

    public int score = 0;

    public float difficultyTimer = 0f;
    public float spawnTimer = 0;

    private bool firstIngredientEneterd = false;

    private void Awake()
    {
        if (Variables.current == null) new Variables();
        score = Variables.current.score;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Variables.current.difficulty == Variables.Difficulty.EASY) timePerText = timePerTextEasy;
        if (Variables.current.difficulty == Variables.Difficulty.HARD) timePerText = timePerTextHard;


        uiMeterMultiplier = 277f / timePerText;
        nextIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Variables.current.score);


        difficultyTimer += Time.deltaTime;
        uiScore.text = "SCORE: " + score;
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

        Vector4 mask = uiMeterMask.padding;
        mask.z = currentTime * uiMeterMultiplier;
        uiMeterMask.padding = mask;

        if (!completed)
        {
            if (firstIngredientEneterd)
                currentTime += Time.deltaTime;

            uiTimer.text = "" + (timePerText -  currentTime);

            if (timePerText - currentTime < 0)
            {
                Variables.current.score = score;
                SceneManager.LoadScene("explosion", LoadSceneMode.Single);
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
        int currentTimeHandicap = difficulty - 9;
        if (currentTimeHandicap <= 0) currentTimeHandicap = 0;
        currentTime = 0 + currentTimeHandicap;
        int random = Random.Range(0, IngredientsList.list.ingredients.Count);
        currentIngredient = IngredientsList.list.Get(random);
        completed = false;
        uiText.SetBaseText(currentIngredient.GenerateName(difficulty));
        crunchBuffer = currentIngredient.getGeneratedName();
    }

    public void FinishIngredient()
    {

        if (!firstIngredientEneterd)
        {
            firstIngredientEneterd = true;
            PlayMusic.current.Play();
        }

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
