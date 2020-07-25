using System.Collections;
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
    public Color imageColor; //This is what visbile in game.

    [HideInInspector] public Button buttonComponent; //Action will take place
    [HideInInspector] public Image imageComponent;

    public bool isHead;   //Whether this is head or not.
    private static bool firstHeadFound;
    //private static bool inProgress = false; //Static variable

    //event actions
    public UnityEvent flowCompleted;
    public UnityEvent moveCompleted;


    [HideInInspector]
    public static List<Square_View> matchFoundlist = new List<Square_View>(); //This is where the matching box colors will be stored.
    //Deleted after completion.

    void Start()
    {
        PlayerPrefs.DeleteAll(); //Will clear if any ID is available.
        //buttonText = GetComponentInChildren<Text>();

        imageComponent = GetComponent<Image>();
        //imageColor = imageComponent.color;  //First getting set as per inspector.

        imageComponent.color = Color.gray;  //Gray color being assigned.

        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(GetSavedIDValue);
        buttonComponent.onClick.AddListener(ChnageColorHead);
    }

    private void Update()
    {
        Debug.Log("Status of first head is:" + firstHeadFound);
    }

    //Changing the color of button when pressed as per the defined image color in inspector.
    public void ChnageColorHead()
    {
        if (isHead)
        {
            imageComponent.color = imageColor; //Setting the color saved at line 45.
        }
        savingColor(imageColor);  //Saving the values of color saved at line 45.
    }

    public void GetSavedIDValue()
    {
        //Debug.Log("Status of first head is:" + firstHeadFound);

        int x = 0;
        Color setColor;


        if (PlayerPrefs.HasKey("ID")) //if id is found 2 conditions will be checked.
        {
            x = PlayerPrefs.GetInt("ID"); //Storing the id saved via playerprefs in local variable.

            //Setting color values as per player prefs.
            setColor = new Color(PlayerPrefs.GetFloat("rValue", 1F), PlayerPrefs.GetFloat("gValue", 1F), PlayerPrefs.GetFloat("bValue", 1F), PlayerPrefs.GetFloat("aValue", 1F));

            //Debug.Log("The saved id is: " + x);
            if (x == ID) //Case1 - If ID of next box Matches
            {
                if (isHead != true) //Normal boxes
                {
                    //Debug.Log("The match has been found for Color: " + imageColor.ToString());

                    //inProgress = true;
                    imageColor = setColor;
                    imageComponent.color = imageColor; //Applying the saved value in playerprefs to the image color.

                    AddTo_Disable();
                    
                    //Debug.Log("Total count of the list is: " + matchFoundlist.Count);
                }
                else if (isHead && firstHeadFound) //This means line is completed.
                {
                    firstHeadFound = false;
                    Debug.Log("This line is completed.");
                    matchFoundlist.Add(this);
                    //inProgress = false;

                    //PlayerPrefs.DeleteAll();
                    PlayerPrefs.DeleteKey("ID");

                    //This will invoke a method for achievement system.
                    Invoke("WinSystem", 0.2f);

                    //Debug.Log("Setting firsthead to: " + firstHeadFound);
                }

            }
            else   //Case2 - If ID of next box does not match.
            {
                if (isHead)
                {
                    firstHeadFound = true;    //Both selected are heads so no need to chnge the status of head.
                    

                    moveCompleted.Invoke();
                    //inProgress = false;
                    PlayerPrefs.SetInt("ID", ID);
                    savingColor(imageComponent.color);

                    //Reseting previous list.
                    resetColors();

                    Invoke("AddTo_Disable", 0.1f);
      
                }
                else  //Clear everything
                {
                    firstHeadFound = false;
                    PlayerPrefs.DeleteKey("ID");

                    //PlayerPrefs.SetString("Failed","true");

                    resetColors();

                    //Debug Log("Deleting Key");
                    //Debug.Log("Clearing list. Count is: " + matchFoundlist.Count);
                }


            }

        }
        else   //if ID is not found
        {
            //Debug.Log("This should run!!");
            if (isHead && !firstHeadFound)  //Will run when game first starts.
            {
                firstHeadFound = true; //bool is getting true.
                matchFoundlist.Add(this);

                //imageComponent.raycastTarget = !firstHeadFound;
                //Debug.Log("Settings raycast target to: " + !firstHeadFound);

                PlayerPrefs.SetInt("ID", ID); //if no id is available then this will be called.

                //PlayerPrefs.SetString("Color", TextColor.ToString());

                savingColor(imageComponent.color);   //Saving color from the image of the button.

                Debug.Log("Saving ID: " + ID + ". Color saved is: " + imageColor.ToString());
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

        //Debug.Log("Saving color values." + colorOfButton.r + colorOfButton.g + colorOfButton.b);
    }

    //Reseting the color data of the images in the list
    private void resetColors()
    {

        moveCompleted.Invoke();
        //Debug.Log("Match not found. Reseting the colors");
        for (int i = 0; i < matchFoundlist.Count; i++)
        {
            matchFoundlist[i].imageComponent.color = Color.gray;
        }
        EnableObjects();

    }



    //Disable list as soon as move is completed. List will be cleared in the end as well.
    private void WinSystem()
    {
        int i = matchFoundlist.Count; //5

        Debug.Log("Count is: " + i);
        //If previous waale matchfound mein isHead off hai. then only this win condition.
        if (matchFoundlist[i - 2].isHead == false)  //4
        {
            for (int j = 0; j < i; j++)
            {
                matchFoundlist[j].imageComponent.raycastTarget = false;
            }
            flowCompleted.Invoke();  //Event invoked means line has been completed.
            moveCompleted.Invoke();
            //Debug.Log("You have won");
        }

        else if (matchFoundlist[i-2].isHead) //In case we click directly on the next head.
        {
            Debug.Log("This will be fucking called");
            for (int k = 0; k < i; k++)
            {
                matchFoundlist[k].imageComponent.raycastTarget = true;
                matchFoundlist[k].imageComponent.color = Color.gray;
            }
            moveCompleted.Invoke();
        }

        matchFoundlist.Clear();
        
    }


    //Add and Disable objects
    private void AddTo_Disable()
    {
        //Debug.Log("Adding to disable list");
        matchFoundlist.Add(this);
        for (int i = 0; i < matchFoundlist.Count; i++)
        {
            matchFoundlist[i].imageComponent.raycastTarget = false;
        }
    }


    //Enable again if line not completed.
    private void EnableObjects()
    {
        for (int i = 0; i < matchFoundlist.Count; i++)
        {
            matchFoundlist[i].imageComponent.raycastTarget = true;
        }
        matchFoundlist.Clear();
    }

}

