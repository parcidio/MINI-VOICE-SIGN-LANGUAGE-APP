using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //variables

    bool menuActive = true;
    public GameObject menu; 

 
    // Update is called once per frame
    void Update()
    {
        if (menuActive)
        {
           // power += Timeout.deltaTime * chargeSpeed;
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

    public void HoldButton()
    {
        //buttonHelpDown = true;
        if (menuActive)
        {
            menuActive = false;
        }
        else
        {
            menuActive = true;
        }
    }

}
