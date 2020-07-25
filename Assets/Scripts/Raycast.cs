using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    Vector3 mousePos;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //mousePos = new Vector3(mainCam.WorldToScreenPoint(Input.GetMouseButtonDown(0));
        }
    }
}
