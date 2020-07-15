using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSpecificManager : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenu;
    public Button nextLevel;
    public Button pause;

    public TextMeshProUGUI levelLabel;

    public TextMeshProUGUI levelStatus;
     
    private Scene activeScene;
    private int buildIndex;

    public GameObject gameOverCanvas;
    private bool gameWon = false;


    private void Start()
   {
        gameOverCanvas.gameObject.SetActive(false);
       
        activeScene = SceneManager.GetActiveScene();
        buildIndex = activeScene.buildIndex;

        Debug.Log("Index of active scene is: " + buildIndex);

        restartButton.onClick.AddListener(RestartLevel);
        mainMenu.onClick.AddListener(LoadMainMenu);
        pause.onClick.AddListener(LoadPauseMenu);
        nextLevel.onClick.AddListener(LoadNextLevel);

        LevelLabelUpdate();

        AchievementSystem.instance.allFlowsCompleted += winCondition;
     
    }

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameOverCanvas.gameObject.SetActive(false);
        }

    }

    //Called when event is invoked.
    private void winCondition()
    {
        levelComplete();
        if (buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            levelStatus.text = "You finished the game!";
        }
    }

    private void levelComplete()
    {
        gameOverCanvas.gameObject.SetActive(true);
        gameWon = true;
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(buildIndex);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Pause button functionality
    private void LoadPauseMenu()
    {
;       gameOverCanvas.gameObject.SetActive(true);
    }



    private void LoadNextLevel()
    {
        if(gameWon)
        {
            nextLevelStatus();
            gameWon = false;
        }
        else
        {
           StartCoroutine(LevelStatusMessage());
        }
    }

    private void nextLevelStatus() 
    {
        if (buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            levelStatus.text = "You have completed all levels";
        }
        else
        {
            Debug.Log("Loading next Level");
            gameOverCanvas.gameObject.SetActive(false);
            SceneManager.LoadScene(++buildIndex);
        }
    }

    private IEnumerator LevelStatusMessage()
    {
        Debug.Log("Coroutines started");
        levelStatus.text = "Please complete the level.";
        yield return new WaitForSeconds(2f);
        gameOverCanvas.SetActive(false);
        levelStatus.text = "";
    }

    private void LevelLabelUpdate()
    {
        levelLabel.text = "Level: " + buildIndex;
    }
}
