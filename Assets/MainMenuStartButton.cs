using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuStartButton : MonoBehaviour
{

    public GameObject tut;

    public enum ButtonType
    {
        EASY, HARD, MAIN_MENU, TRY_AGAIN, OPEN_TUT
    }

    public ButtonType diff;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        switch(diff)
        {
            case ButtonType.EASY:
                StartEasy();
                break;
            case ButtonType.HARD:
                StartHard();
                break;
            case ButtonType.MAIN_MENU:
                MainMenu();
                break;
            case ButtonType.TRY_AGAIN:
                TryAgain();
                break;
            case ButtonType.OPEN_TUT:
                tut.SetActive(true);
                break;
        }
    }

    public void StartEasy()
    {
        MainMenuController.current.StartEasy();
    }

    public void StartHard()
    {
        MainMenuController.current.StartHard();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void TryAgain()
    {
        switch (Variables.current.difficulty) {
            case Variables.Difficulty.EASY:
                StartEasy();
                break;
            case Variables.Difficulty.HARD:
                StartHard();
                break;
        }
    }
}
