using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeButtonScript : MonoBehaviour
{
    [SerializeField] private Material material;
    public Camera cam;
    public Text displayText;
    public Text titleText;
    private bool mainThemeOn;

    private Color32 mainColor = Color.green;
    private Color32 secondColor = Color.white;

    void Start()
    {
        mainColor.a = 255;
        mainColor.r = 42;
        mainColor.g = 49;
        mainColor.b = 61;

        //secondColor.a = 225;
        secondColor.r = 225;
        secondColor.g = 225;
        secondColor.b = 225;



         //cam = GetComponent<Camera>();
        //cam.clearFlags = CameraClearFlags.SolidColor;
    }
    // Update is called once per frame
    void Update()
    {
        if (mainThemeOn)
        {
            //dark theme
            material.color = secondColor;
            cam.backgroundColor = mainColor;
           
            displayText.color = secondColor;
            titleText.color = mainColor;
          
        }
        else
        {
           //light theme
            material.color = secondColor;
            cam.backgroundColor = Color.white;
  
          displayText.color = mainColor;
            titleText.color = Color.white;
        }
    }

    public void ButtonPressed()
    {
        //buttonHelpDown = true;
        if (mainThemeOn)
        {
            mainThemeOn = false;
            Toast.Instance.Show("Theme: Dark", .5f);

        }
        else
        {
            mainThemeOn = true;
            Toast.Instance.Show("Theme: Light", .5f);
        }
        Debug.Log("Theme Changed: " + mainThemeOn);
    }

}
