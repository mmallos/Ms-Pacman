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
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown("right"))
        {
            if (currentPac == 0)
            {
                if (enemies < 4)
                {
                    enemies += 1;
                    enemiesText.text = "Enemies: " + enemies.ToString();
                }
            }
            else if (currentPac == 1)
            {
                PSpeed += 5;
                PSpeedText.text = "Player Speed: " + PSpeed.ToString();
            }
            else if (currentPac == 2)
            {
                ESpeed += 5;
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
        else if (Input.GetKeyDown("left"))
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
        else if (Input.GetKeyDown("down"))
        {
            if (currentPac <3)
            {
                pacs[currentPac].SetActive(false);
                currentPac += 1;
                pacs[currentPac].SetActive(true);
            }

            
        }
        else if (Input.GetKeyDown("up"))
        {
            if (currentPac > 0)
            {
                pacs[currentPac].SetActive(false);
                currentPac -= 1;
                pacs[currentPac].SetActive(true);
            }
            
        }

        if (Input.GetKeyDown("return"))
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