using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController current;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Variables.current == null) new Variables();
    }

    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEasy()
    {
        Variables.current.score = 0;
        Variables.current.score += 1;
        Variables.current.difficulty = Variables.Difficulty.EASY;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void StartHard()
    {
        Variables.current.score = 0;
        Variables.current.difficulty = Variables.Difficulty.HARD;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
