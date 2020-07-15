using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject levelButtonPanels;
    public GameObject rulesPanels;


    public Button startButton;
    public Button backButton;
    public Button loadHelp;
    public Button closeHelp;
  
    public List<Button> levelButtons;
    [SerializeField]private TextMeshProUGUI levelText;

    private bool Page1Inactive = false; 
    private  bool Page2Inactive = true;
    private bool rulesLoad = false;

    private int levelCount = 1;
    
    private void Awake()
    {
        rulesPanels.gameObject.SetActive(false);
    }

    void Start()
    {
        LevelNaming();

        startButton.onClick.AddListener(StartBackFunctionality);
        backButton.onClick.AddListener(StartBackFunctionality);

        loadHelp.onClick.AddListener(LoadHowToPlay);
        closeHelp.onClick.AddListener(LoadHowToPlay);
    }

    private void LevelNaming()
    {
        for (int i = 0; i < levelButtons.Count; i++)
        {
            levelText = levelButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            levelText.text = "Level " + levelCount;
            levelCount++;
        }

    }

    //Setting Canvas active and inactive.
    private void StartBackFunctionality()
    {
        if(Page2Inactive)
        {
            Page2Inactive = false;
            Page1Inactive = true;
            levelButtonPanels.gameObject.SetActive(true);
            startPanel.gameObject.SetActive(false);
        }
        else if (Page1Inactive)
        {
            Page2Inactive = true;
            Page1Inactive = false;
            levelButtonPanels.gameObject.SetActive(false);
            startPanel.gameObject.SetActive(true);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void LoadHowToPlay()
    {
        if(!rulesLoad)
        {
            rulesPanels.gameObject.SetActive(true);
            rulesLoad = !rulesLoad;
        }
        else if(rulesLoad)
        {
            rulesPanels.gameObject.SetActive(false);
            rulesLoad = !rulesLoad;
        } 
    }


}
