using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSpecificManager : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenu;
   
   private void Start()
   {
       restartButton.onClick.AddListener(RestartLevel);
       mainMenu.onClick.AddListener(LoadMainMenu);
   }

    private void RestartLevel()
    {
       Scene activeScene = SceneManager.GetActiveScene();

       SceneManager.LoadScene(activeScene.buildIndex);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
