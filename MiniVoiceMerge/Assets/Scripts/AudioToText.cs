using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToText : MonoBehaviour
{
    bool isTranscribing;
    // Start Audio to text
    public void AudioToTextButton()
    {
        if (isTranscribing)
        {
            Toast.Instance.Show("Started transcribing...", 1f, Toast.ToastColor.Green);
            Debug.Log("Started transcribing...");
        }
        else
        {
            Toast.Instance.Show("Ended transcribing...", 1f, Toast.ToastColor.Red);
            Debug.Log("Ended transcribing...");
        }

    }
    //On finger press
    public void pointerDown()
    {
        isTranscribing = true;
        AudioToTextButton();

    }
    //On Finger release
    public void pointerUp()
    {
        isTranscribing = false;
        AudioToTextButton();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
