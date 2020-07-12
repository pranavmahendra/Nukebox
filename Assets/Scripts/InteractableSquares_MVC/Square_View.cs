using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Square_View : MonoBehaviour
{
    public int id;
    public Color Scolor;
    private Image image;

    private int count = 0;

    private Button button; //Action will take place

    void Start()
    {
        image = GetComponent<Image>();
        image.color = Scolor;

        button = GetComponent<Button>();
        buttonsPressed();
    }

    void printName()
    {
       Debug.Log("The name of the pressed buttons is: " + gameObject.name);
       image.color = Color.green;
    }

    void buttonsPressed()
    {
        button.onClick.AddListener(printName);
    }

    //Method banana hoga which basically checks if id is same on top,right,left,bottom.
 

}
