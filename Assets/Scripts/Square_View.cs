﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//red = 1
//green = 2
//blue = 3
//yellow = 4
//orange = 5

public class Square_View : MonoBehaviour
{
    //public Text buttonText;

    public int ID;
    //public Color TextColor;
    public Color imageColor;

    [HideInInspector] public Button buttonComponent; //Action will take place
    [HideInInspector] public Image imageComponent;

    public bool isHead;   //Whether this is head or not.
    private  bool firstHeadFound = false;

    //event actions
    public UnityEvent flowCompleted;
    public UnityEvent moveCompleted;

    [HideInInspector]
    public static List<Square_View> matchFoundlist = new List<Square_View>(); //This is where the matching box colors will be stored.
    //Deleted after completion.


    private void Awake()
    {
        PlayerPrefs.DeleteKey("ID"); //Will clear if any ID is available.
    }

    void Start()
    {
        //buttonText = GetComponentInChildren<Text>();

        imageComponent = GetComponent<Image>();
        imageColor = imageComponent.color;

        if (isHead != true)
        {
            //buttonText.color = Color.white;
            //buttonText.fontSize = 20;
            imageComponent.color = Color.gray;
        }


        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(GetSavedIDValue);
    }



    public void GetSavedIDValue()
    {
   
        int x = 0;
        Color setColor;
        

        if (PlayerPrefs.HasKey("ID")) //if id is found 2 conditions will be checked.
        {
            x = PlayerPrefs.GetInt("ID"); //Storing the id saved via playerprefs in local variable.

            //Setting color values as per player prefs.
            setColor = new Color(PlayerPrefs.GetFloat("rValue", 1F), PlayerPrefs.GetFloat("gValue", 1F), PlayerPrefs.GetFloat("bValue", 1F), PlayerPrefs.GetFloat("aValue", 1F));

            Debug.Log("The saved id is: " + x);
            if (x == ID) //Case1 - If ID of next box Matches
            {
                if (isHead != true)
                {
                    Debug.Log("The match has been found for Color: " + imageColor.ToString());

                    imageColor = setColor;
                    imageComponent.color = imageColor; //Applying the saved value in playerprefs to the image color.

                    //buttonText.color = TextColor;

                    matchFoundlist.Add(this);
                    Debug.Log("Total count of the list is: " + matchFoundlist.Count);
                }
                else if (isHead && !firstHeadFound) //Other head will always have this value as false by default.
                {
                    Debug.Log("This line is completed.");

                    flowCompleted.Invoke();  //Event invoked means line has been completed.
                      
                    moveCompleted.Invoke();

                    //PlayerPrefs.DeleteAll();
                    PlayerPrefs.DeleteKey("ID");
                    //This will invoke a method for achievement system.
                    matchFoundlist.Clear();
                    Debug.Log("Setting firsthead to: " + firstHeadFound);
                }
            }
            else   //Case2 - If ID of next box does not match.
            {
                if (isHead)
                {
                    moveCompleted.Invoke();

                    PlayerPrefs.SetInt("ID", ID);  
                    savingColor(imageComponent.color);

                }
                else
                {

                    PlayerPrefs.DeleteKey("ID");

                    PlayerPrefs.SetString("Failed","true");
                 
                    resetColors();
                    matchFoundlist.Clear();

                    Debug.Log("Deleting Key");
                    Debug.Log("Clearing list. Count is: " + matchFoundlist.Count);
                }


            }

        }
        else   //if ID is not found
        {
            Debug.Log("This should run!!");
            if (isHead && !firstHeadFound)
            {
                firstHeadFound = true; //bool is getting true.

                Debug.Log("Status if first head is:" + firstHeadFound);

                PlayerPrefs.SetInt("ID", ID); //if no id is available then this will be called.

                //PlayerPrefs.SetString("Color", TextColor.ToString());

                savingColor(imageComponent.color);   //Saving color from the image of the button.

                Debug.Log("Saving ID" + ID + ". Color saved is: " + imageColor.ToString());
            }
            else if (isHead && firstHeadFound)
            {
            
               if (PlayerPrefs.HasKey("Failed"))
                {
                    PlayerPrefs.SetInt("ID", ID);
                    savingColor(imageComponent.color);
                    PlayerPrefs.DeleteKey("Failed");
                }
                
            }
         
        }
    }


    //Saving Color data.
    private void savingColor(Color color)
    {
        Color colorOfButton = color;
        PlayerPrefs.SetFloat("rValue", colorOfButton.r);
        PlayerPrefs.SetFloat("gValue", colorOfButton.g);
        PlayerPrefs.SetFloat("bValue", colorOfButton.b);
        PlayerPrefs.SetFloat("aValue", colorOfButton.a);

        Debug.Log("Saving color values." + colorOfButton.r + colorOfButton.g + colorOfButton.b);
    }

    //Reseting the color data of the images in the list
    private void resetColors()
    {

        moveCompleted.Invoke();
        Debug.Log("Match not found. Reseting the colors");
        for (int i = 0; i < matchFoundlist.Count; i++)
        {
            matchFoundlist[i].imageComponent.color = Color.gray;
            
        }
    }

}

