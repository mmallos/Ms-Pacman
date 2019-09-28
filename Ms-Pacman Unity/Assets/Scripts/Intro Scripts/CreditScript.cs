using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour //Handles credits and moving to other scenes
{
    private int credits;
    public AudioSource CoinInput;
    public Text creditsText;
    // Start is called before the first frame update
    void Start()
    {
        credits = 0;
        creditsText.text = "Credit " + credits.ToString();

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) //If input is 1 "inserts coin"
        {
            credits += 1;
            creditsText.text = "Credit " + credits.ToString();
            CoinInput.Play(0);
        }

        if (credits > 0) //Only allows changing of scenes if there is one or more coins inserted
        {
            if (Input.GetKeyDown("return")) //scene manager to change to either level one or level two's settings area 
            {
                credits -= 1;
                creditsText.text = "Credit " + credits.ToString();
                SceneManager.LoadScene("LevelOne");
            }
            if (Input.GetKeyDown("space"))
            {
                credits -= 1;
                creditsText.text = "Credit " + credits.ToString();
                SceneManager.LoadScene("LevelTwoSettings");
            }
        }

    }
}
