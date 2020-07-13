using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementSystem : MonoBehaviour
{
    public TextMeshProUGUI flowText;
    public TextMeshProUGUI movesText;
    public TextMeshProUGUI pipeText;

    private int flowCount = 0;
    private int moveCount = 0;
    private int pipePercent = 0;
  
 
    private void Start()
    {

        flowText.text = "Flows: 0/5";
        movesText.text = "Moves: " + moveCount;
        pipeText.text = "Pipe: " + pipePercent + "%";

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
    }

    public void UpdateFlowText()
    {
        flowCount++;
        pipePercent += 20;
        flowText.text = "Flows: " + flowCount + "/5";
        pipeText.text = "Pipe: " + pipePercent + "%";
    }

    public void updateMoves()
    {
        moveCount++;   
        movesText.text = "Moves: " + moveCount;
    }

 

}
