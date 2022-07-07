using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject sendButton;
    public GameObject audioButton;
    TouchScreenKeyboard keyboard;
    bool isTranscribing;
    private void Start()
    {
        isTranscribing = false;
    }

    // Open the keyboard when the inputField is clicked

    public void OpenKeyboard ()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true,  true);
       
    }

    public void pointerDown()
    {
        isTranscribing = true;
       

    }
    //On Finger release
    public void pointerUp()
    {
        isTranscribing = false;
       

    }
    // Update is called once per frame
    void Update()
    {
        if(TouchScreenKeyboard.visible == false && keyboard != null)
        {
            //TouchScreenKeyboard.hideInputs =false;
            inputField.text = keyboard.text;
        }
        if (inputField.text.Length != 0 && isTranscribing == false)
        {
            // power += Timeout.deltaTime * chargeSpeed;
            sendButton.SetActive(true);
            audioButton.SetActive(false);

        }
        else
        {
           

            sendButton.SetActive(false);
            audioButton.SetActive(true);

        }

    }
}
