using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateScript : MonoBehaviour
{

    public Transform Rotatable;
    private float RotationSpeed = .21f;

    bool ismouseheld;
    Vector2 currentMousePosition;
    Vector2 mouseDeltaPosition;
    Vector2 lastMousePosition;
    bool istouchpadactive;
    float angle;
    float limit;

    bool isPaused;
   

    private void Start()
    {
        ResetMousePosition();
        ResetPosition();

    }

    void Update()
    {
        

        if (istouchpadactive)
        {
            angle = Mathf.Clamp(mouseDeltaPosition.x * (RotationSpeed * -1), -3, 3);
            limit = Rotatable.eulerAngles.y;
         

            {
               
                currentMousePosition = Input.mousePosition;
                mouseDeltaPosition = currentMousePosition - lastMousePosition;
                Rotatable.transform.Rotate(0f, angle, 0f);
      
                lastMousePosition = currentMousePosition;
               

            }
          
        }
    }

    public void ActivateTouchpad()
    {
        ResetMousePosition();
        istouchpadactive = true;
        Pause();
    }

    public void DeactivateTouchpad()
    {
        istouchpadactive = false;
        Pause();
    }

     public void ResetMousePosition()
    {
        currentMousePosition = Input.mousePosition;
        lastMousePosition = currentMousePosition;
        mouseDeltaPosition = currentMousePosition - lastMousePosition;
        
    }
    public void ResetPosition()
    {
        Rotatable.transform.Rotate(0f, 0f, 0f);
    }
    
    //*************** PAUSE SCRIPT **************
    public void Pause()
    {
        if (isPaused) 
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
