using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    private int[,] intArr = new int[5,5] {{1,1,1,1,2},{1,3,3,2,2},{1,3,4,4,4},{4,3,4,5,4},{4,4,4,5,5}}; //5 rows and 5 coloumns.

    public List<Text> arrayDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        PrintElements();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintElements()
    {
        int tempPointer = 0;

        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                Debug.Log("The elements of the array at [" + i + "][" + j + "] : " + intArr[i,j]);

                arrayDisplay[tempPointer].text = intArr[i,j].ToString();
                tempPointer++;
            }
        }
    }
    

}
