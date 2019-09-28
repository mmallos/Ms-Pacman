using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    public int lives;
    public AudioSource CoinInput;
    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = 0;
        livesText.text = "Credit " + lives.ToString();

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            lives += 1;
            livesText.text = "Credit " + lives.ToString();
            CoinInput.Play(0);
        }

        if (lives > 0)
        {
            if (Input.GetKeyDown("return"))
            {
                lives -= 1;
                livesText.text = "Credit " + lives.ToString();
                SceneManager.LoadScene("LevelOne");
            }
            if (Input.GetKeyDown("space"))
            {
                lives -= 1;
                livesText.text = "Credit " + lives.ToString();
                SceneManager.LoadScene("LevelTwoSettings");
            }
        }

    }
}
