using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Border;
    public GameObject titleText;
    public GameObject startText;
    public GameObject bonusText;
    public GameObject bonusMsPacman;
    public GameObject RedGhost;
    public GameObject PurpleGhost;
    public GameObject BlueGhost;
    public GameObject GreenGhost;
    public GameObject Clyde;
    public GameObject Blinky;
    public GameObject Purply;
    public GameObject Inky;
    public GameObject With;

    // Start is called before the first frame update
    void Start()
    {
        startText.SetActive(false);
        bonusText.SetActive(false);
        bonusMsPacman.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) //Changes screen to start screen by deactivating all former elements and activating all start screen elements
        {
            if (titleText.activeSelf)
            {
                titleText.SetActive(false);
                bonusText.SetActive(true);
                startText.SetActive(true);
                bonusMsPacman.SetActive(true);
                RedGhost.SetActive(false);
                BlueGhost.SetActive(false);
                PurpleGhost.SetActive(false);
                GreenGhost.SetActive(false);
                Inky.SetActive(false);
                Purply.SetActive(false);
                Clyde.SetActive(false);
                Blinky.SetActive(false);
                With.SetActive(false);
                Border.SetActive(false);
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Lives");
            foreach (GameObject go in gos)
                Destroy(go);
        }

    }
}
