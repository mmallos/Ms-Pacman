﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomGame : MonoBehaviour
{
    public GameObject PlayerOneText;
    public AudioSource MainMusic;
    public GameObject ReadyText;
    public GameObject RedGhost;
    public GameObject MsPacMan;

    // Start is called before the first frame update
    void Start()
    {
        MsPacMan.SetActive(false);
        RedGhost.SetActive(false);
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

    }
    IEnumerator StartGame()
    {
        Time.timeScale = 0; // pause
        float t = 0;
        while (t < 2.7f)
        {
            yield return null; //runs the coroutine continuously
            t += Time.unscaledDeltaTime; // returns deltaTime without being multiplied by Time.timeScale
        }
        PlayerOneText.SetActive(false);
        ReadyText.SetActive(false);
        MsPacMan.SetActive(true);
        RedGhost.SetActive(true);
        MainMusic.Play();
        Time.timeScale = 1; // restore time scale from before pause
    }
}
