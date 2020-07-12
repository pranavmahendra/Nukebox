using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLogic : MonoBehaviour
{

    private int[,] intArr = new int[5,5] {{1,1,1,1,2},{1,3,3,2,2},{1,3,4,4,4},{4,3,4,5,4},{4,4,4,5,5}}; //5 rows and 5 coloumns.

    public List<Square_View> InteractableSquares;
    public List<Text> arrayDisplay;

    public int[,] arr1;
    private int count = 0;

    void Start()
    {
        PrintElements();
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

    void CheckIDs()
    {
        for (int i = 0; i < InteractableSquares.Count; i++)
        {
            if(count == 0)
            {

            }
        }
    }
}

//Points in mind
//Jaha touch karega woh starting point.
//Uske aage woh ya toh upar jayega ya right. only 2 movements.
//2 conditions hongi. Aagar match hogya then continue, warna break.
//Condition check kaise hogi: array ke numbers ko id ki tarah use karke. 
//id match karayenge.
