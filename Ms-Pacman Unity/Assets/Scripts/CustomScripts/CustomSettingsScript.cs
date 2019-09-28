using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomSettingsScript : MonoBehaviour
{

    public GameObject CustomController;
    public GameObject[] pacs;
    public Text enemiesText;
    public Text PSpeedText;
    public Text ESpeedText;
    public Text SuperText;
    public float ESpeed;
    public float PSpeed;
    public string superPac;
    public int enemies;
    int currentPac = 0;
    // Start is called before the first frame update
    void Start()
    {
        superPac = "Super Pellet";
        pacs[1].SetActive(false);
        pacs[2].SetActive(false);
        pacs[3].SetActive(false);
        //pacs[4].SetActive(false);
        enemies = 4;
        PSpeed = 10;
        ESpeed = 10;
        enemiesText.text = "Enemies: " + enemies.ToString();
        PSpeedText.text = "Player Speed: " + PSpeed.ToString();
        ESpeedText.text = "Enemy Speed: " + ESpeed.ToString();
    }

    // Update is called once per frame
    void Update() //This script allows the player to select a custom game of ms-pacman using various movement, special and enemy options
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown("right")) //The UI works using an int "currentPac" to determine what setting the user is editing and small MsPacman gameobjects to tell the user what they are editing.
        {
            if (currentPac == 0) //Checks what setting the player is specifying
            {
                if (enemies < 4) //Increases the enemy count if it is less than 4
                {
                    enemies += 1;
                    enemiesText.text = "Enemies: " + enemies.ToString();
                }
            }
            else if (currentPac == 1) //Otherwise changes the players speed if they are at the second option
            {
                PSpeed += 5;
                PSpeedText.text = "Player Speed: " + PSpeed.ToString();
            }
            else if (currentPac == 2) //Otherwise changes the enemy speed if they are at the third option
            {
                ESpeed += 5;
                ESpeedText.text = "Enemy Speed: " + ESpeed.ToString();
            }
            else if (currentPac == 3) //Otherwise changes the power-up at the fourth option
            {
                if (superPac.Equals("Super Pellet"))
                {
                    superPac = "TimeStop";
                }
                else if (superPac.Equals("TimeStop"))
                {
                    superPac = "Super Pellet";
                }
                SuperText.text = "Power-Up: " + superPac;
            }
        }
        else if (Input.GetKeyDown("left")) //Same as the above section but decrements (except in the power-up example where it simply toggles)
        {
            if (currentPac == 0)
            {
                if (enemies > 0)
                {
                    enemies -= 1;
                    enemiesText.text = "Enemies: " + enemies.ToString();
                }
            }
            else if (currentPac == 1)
            {
                PSpeed -= 5;
                PSpeedText.text = "Player Speed: " + PSpeed.ToString();
            }
            else if (currentPac == 2)
            {
                ESpeed -= 5;
                ESpeedText.text = "Enemy Speed: " + ESpeed.ToString();
            }
            else if (currentPac == 3)
            {
                if (superPac.Equals("Super Pellet"))
                {
                    superPac = "TimeStop";
                }
                else if (superPac.Equals("TimeStop"))
                {
                    superPac = "Super Pellet";
                }
                SuperText.text = "Power-Up: " + superPac;
            }
        }
        else if (Input.GetKeyDown("down")) //moves the selected option down if they are not at the bottom of the list
        {
            if (currentPac <3)
            {
                pacs[currentPac].SetActive(false);
                currentPac += 1;
                pacs[currentPac].SetActive(true);
            }

            
        }
        else if (Input.GetKeyDown("up")) //Moves the selected option up if they are not at the top of the list
        {
            if (currentPac > 0)
            {
                pacs[currentPac].SetActive(false);
                currentPac -= 1;
                pacs[currentPac].SetActive(true);
            }
            
        }

        if (Input.GetKeyDown("return")) //Saves all the settings to four different player preferences. Multiplies the enemy speed to make the selected speed feel similar to MsPacmans
        {
            PlayerPrefs.SetInt("enemies", enemies);
            PlayerPrefs.SetFloat("PSpeed", PSpeed);
            ESpeed = ESpeed * 6;
            PlayerPrefs.SetFloat("ESpeed", ESpeed);
            PlayerPrefs.SetString("Super", superPac);
            SceneManager.LoadScene("LevelTwo");
            }

        
    }
}