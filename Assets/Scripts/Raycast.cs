using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Raycast : MonoBehaviour
{

    Camera mainCam;
    


    void Start()
    {
        mainCam = Camera.main;
    }

  
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ScreenMouseRay();
        }
        
    }

    public void ScreenMouseRay()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Infinity;

        //Debug.Log(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, mousePosition - mainCam.ScreenToWorldPoint(mousePosition), Mathf.Infinity);

        Debug.DrawRay(mousePosition, mousePosition - mainCam.ScreenToWorldPoint(mousePosition), Color.blue);
        if(hit.collider.gameObject.GetComponent<Square_View>() != null)
        {
            Debug.Log("Target hit: " + hit.collider.gameObject.name);
    
        }

    }
}
