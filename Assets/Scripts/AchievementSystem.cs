using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class AchievementSystem : MonosingletonGeneric<AchievementSystem>
{
    public TextMeshProUGUI flowText;
    public TextMeshProUGUI movesText;
    public TextMeshProUGUI pipeText;

    private  int flowCount = 0;
    private int moveCount = 0;
    private int pipePercent = 0;

    public event Action allFlowsCompleted;
  
 
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

        if (flowCount == 5)
        {
            allFlowsCompleted?.Invoke();
        }
    }

    public void updateMoves()
    {
        moveCount++;   
        movesText.text = "Moves: " + moveCount;
    }
}
