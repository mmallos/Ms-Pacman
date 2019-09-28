using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject PlayerOneText;
    public GameObject ReadyText;
    public GameObject RedGhost;
    public GameObject BlueGhost;
    public GameObject PurpleGhost;
    public GameObject GreenGhost;
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
            //GameObject[] gos = GameObject.FindGameObjectsWithTag("Lives");
            //foreach (GameObject go in gos)
            //    Destroy(go);
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

        Time.timeScale = 1; // restore time scale from before pause
    }
}
