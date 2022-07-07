using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TranslateScript : MonoBehaviour
{
    //Variable of game objects
    //public GameObject sara;
    public TMP_InputField inputField;
    public GameObject showText;
    public GameObject translateButton;
    private string translatedText;
    string[] sentence;

    //************ANIMATION VARIABLES**************
    Animator animator;
    string currentState;
    Dictionary<char, string> alphabet = new Dictionary<char, string>();
    Dictionary<string, string> words = new Dictionary<string, string>();
    Dictionary<string, string> poses = new Dictionary<string, string>();

    int animationSpeed ;
    private IEnumerator ReferenceCoroutine;

    //**********************************************
    private void Start()
    {
        translatedText = inputField.text.ToLower();

        Debug.Log("Everything is set...");
        //************************ANIMATION PLAY ON START********************** 

        {
            alphabet.Add('a', "RIG-rain|a"); alphabet.Add('b', "RIG-rain|b");
            alphabet.Add('c', "RIG-rain|c"); alphabet.Add('d', "RIG-rain|d");
            alphabet.Add('e', "RIG-rain|e"); alphabet.Add('f', "RIG-rain|f");
            alphabet.Add('g', "RIG-rain|g"); alphabet.Add('h', "RIG-rain|h");
            alphabet.Add('i', "RIG-rain|i"); alphabet.Add('j', "RIG-rain|j");
            alphabet.Add('k', "RIG-rain|k"); alphabet.Add('l', "RIG-rain|l");
            alphabet.Add('m', "RIG-rain|m"); alphabet.Add('n', "RIG-rain|n");
            alphabet.Add('o', "RIG-rain|o"); alphabet.Add('p', "RIG-rain|p");
            alphabet.Add('q', "RIG-rain|q"); alphabet.Add('r', "RIG-rain|r");
            alphabet.Add('s', "RIG-rain|s"); alphabet.Add('t', "RIG-rain|t");
            alphabet.Add('u', "RIG-rain|u"); alphabet.Add('v', "RIG-rain|v");
            alphabet.Add('w', "RIG-rain|w"); alphabet.Add('y', "RIG-rain|y");
            alphabet.Add('x', "RIG-rain|x"); alphabet.Add('z', "RIG-rain|z");
        }
        {
            words.Add("my", "RIG-rain|my");
            words.Add("hallo", "RIG-rain|hallo");
            words.Add("name", "RIG-rain|name");
        }
        {
            poses.Add("idle", "RIG-rain|relaxed_posed");
        }


        animator = GetComponent<Animator>();

        //animator.Play(poses["idle"], 0, 3f);
        //animator.Play(words["hallo"], 0, .95f);
        //animator.Play(poses["idle"]);
        animator.speed = 0.5f;
        showText.GetComponent<Text>().text = "Hallo my name is Sara";
    }



    public void SaveText()
    {
        translatedText = inputField.text.ToLower();
        Debug.Log("translatedText : " + translatedText);
        PlayerPrefs.SetString("LastTranslatedString", translatedText);

    }



    public void ShowText(string text)
    {
        SaveText();
        showText.GetComponent<Text>().text = "";
        showText.GetComponent<Text>().text = text;

    }

    public void DeleteText()
    {
        showText.GetComponent<Text>().text = "";
        animator.CrossFade(poses["idle"], .1f, 0, .5f);
        inputField.text = "";
        PlayerPrefs.SetString("LastTranslatedString", "");
        Toast.Instance.Show("Memory cleared", 1f);
        if(ReferenceCoroutine != null)
        {
            StopTranslateText();
        }
       
        Debug.Log("memory erased");


    }



    //********************ANIMATION**********************
    void ChangeAnimationState(string newState)
    {
        //PLAY ANIMATION ANIMATION
        animator.Play(newState);


    }

    public void TranslateText()
    {
        //TEXT TO SIGN ANIMATION
        SaveText();
        ReferenceCoroutine = TestCoroutine(GetCurrentAnimatorTime(animator, 0));
        StartCoroutine(ReferenceCoroutine);

    } 
    
    public void StopTranslateText()
    {
        //STOP THE TRANSLATION
        StopCoroutine(ReferenceCoroutine);

    }

    //***********Convert***********************
    String[] ConvertSentenceToWords(string sentence)
    {
        char[] separator = { ' ', ',', '.', '/', '\\', '?', '!' };
        //sentence.Trim(); //remove start and end white space....
        // performing the method
        String[] words = sentence.Split(separator,
           StringSplitOptions.RemoveEmptyEntries);

        return words;
    }


    Char[] ConvertWordToLetters(string word)
    {
        // performing the method
        char[] letters = word.ToCharArray();
        Debug.Log("Array of letters: " + letters);
        return letters;
    }

    //***********Validate***********************
    bool ValidateWord(string word)
    {
        //Check if a certain word is part of the indexes in the Word dictionary
        foreach (var entry in words)
        {
            var key = entry.Key;
            var value = entry.Value;

            if (key == word)
            {
                Debug.Log("Key : " + key);
                Debug.Log("Value : " + value);
                return true;
            }

        }

        return false;
    }
    bool ValidateLetter(char letter)
    {
        //Check if a certain letter is part of the indexes in the Letter dictionary
        foreach (var entry in alphabet)
        {
            char key = entry.Key;
            var value = entry.Value;

            if (key == letter)
            {
                return true;
            }
        }

        return false;
    }
    //***************************************
    public static bool IsNullOrEmpty<T>(T[] array) where T : class
    {
        if (array == null || array.Length == 0)
            return true;
        else
            return false;// array.All(item => item == null);
    }

    //******************************************
    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        return currentTime;
    }
    //***********Play Speed***********************
    void SetAnimationSpeed(float mSpeed)
    {
        animator.speed = mSpeed;
    }
    public void SpeedButtonPressed()
    {

        animationSpeed += 1;
        switch (animationSpeed)
        {
            case 1:
                SetAnimationSpeed(0.3f);
                Debug.Log("Speed : " + animationSpeed);
                Toast.Instance.Show("Speed: Slow", 1f);
                break;
            case 2:
                SetAnimationSpeed(0.5f);
                Debug.Log("Speed : " + animationSpeed);
                Toast.Instance.Show("Speed: normal", 1f);
                break;
            /*case 3:
                SetAnimationSpeed(1f);
                Debug.Log("Speed : " + animationSpeed);
                break;*/
            default:
                //SetAnimationSpeed(animationSpeed);
                SetAnimationSpeed(1f);
                Debug.Log("Speed : " + animationSpeed);
                Toast.Instance.Show("Speed: Fast", 1f);
                animationSpeed = 0;

                break;
        }

    }
    // Repeats Animations
    public void RepeatAnimation()
    {
        string stringData = PlayerPrefs.GetString("LastTranslatedString");
        string[] sentence = ConvertSentenceToWords(stringData);
        if (stringData != "")
        {
            foreach (String word in sentence)
            {
                ShowText(word); //Show and save text;
                if (ValidateWord(word))
                {
                    //It's a word that exist in the Dictionary
                    animator.CrossFade(words[word], .1f, 0, .5f);//plays animation with transaction
                    TranslateText();

                }
                else
                {
                    char[] letters = ConvertWordToLetters(word);
                    foreach (char chararcter in letters)
                        if (ValidateLetter(chararcter))
                        {
                            //It's a letter that exist in the Dictionary
                            animator.CrossFade(alphabet[chararcter], .1f, 0, .5f);
                            TranslateText();

                        }
                }

            }
        }
        else
        {
            Toast.Instance.Show("No animation", 1f, Toast.ToastColor.Red);

        }

    }



    IEnumerator TestCoroutine(float d)
    {
        d = d + 2;
        /*when animator.Play() function is placed in this function, in the following manner, complete senteces
         can be animated*/
        // animator.Play("RIG-rain|name", 0, .95f); 
        //yield return new WaitForSeconds(d);
        //Time.timeScale = 0;
        //animator.Play("RIG-rain|my", 0, .95f);

        sentence = ConvertSentenceToWords(translatedText);


        if (!IsNullOrEmpty(sentence))
        {
            //translate the animation to sign languge 
            foreach (String word in sentence)
            {


                ShowText(word); //Show and save text;
                if (ValidateWord(word))
                {
                    //It's a word that exist in the Dictionary

                    animator.CrossFade(words[word], .1f, 0, .5f);
                    Debug.Log("word : " + word);


                }
                else
                {
                  //  d = d + 3;
                    char[] letters = ConvertWordToLetters(word);
                    foreach (char chararcter in letters)
                    {

                        if (ValidateLetter(chararcter))
                        {
                            
                            //It's a letter that exist in the Dictionary
                            animator.CrossFade(alphabet[chararcter], .1f, 0, .35f);
                            Debug.Log("Letter : " + chararcter);
                            
                        }
                        yield return new WaitForSeconds(d-1);
                    }

                }

                yield return new WaitForSeconds(d);

            }

            animator.CrossFade(poses["idle"], .2f, 0, .5f, .1f);
            ShowText("");
        }
        else
        {
            //Alert to enter Translation text
            Toast.Instance.Show("Please enter a valid text", 1f, Toast.ToastColor.Blue);

        }
    }
}
