using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameLogic : MonoBehaviour 
{
    public Square_View childSquare; 
    private Button button;  //Will be attached to every button

    void Start()
    {
        button = GetComponent<Button>();
        childSquare = GetComponent<Square_View>();
        button.onClick.AddListener(GetID);
    }

    public void GetID()
    {
       
    }

    
}

//Points in mind
//Jaha touch karega woh starting point.
//Uske aage woh ya toh upar jayega ya right. only 4 movements.
//2 conditions hongi. Aagar match hogya then continue, warna break.
//Condition check kaise hogi: array ke numbers ko id ki tarah use karke. 
//id match karayenge.
//Playerprefs ke through agar id save karle starting point ki. agar next box mein event
//call hoga compare() karne ka. Agar id match kar gayi then continue otherwise
//PLayerprefs se woh id clear hojayegi dubara start karna