using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsPacman : MonoBehaviour
{
    public Text scoreText;
    public AudioSource pelletEat;
    public AudioSource WinMusic;
    public AudioSource LoseMusic;
    public GameObject[] lives;
    int livesLost = 1;
    private int score = 0;
    public GameObject RedGhost;
    public GameObject BlueGhost;
    public GameObject PurpleGhost;
    public GameObject GreenGhost;
    private bool input = true;
    private bool changedDirection = false;
    private Vector2 lastDirection;
    Quaternion orientation = Quaternion.Euler(0, 0, 0);
    public float speed = 10.0f;
    private Vector2 direction = Vector2.zero;
    int pelletsEaten;

    void Start()
    {
        Destroy(lives[lives.Length-1]); //Removes one of the life objects at the start
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Move();
        CheckOrientation();
    }

    void Movement() //Uses the GetAxis to determine which key the player has pressed and sets the direction to the corresponding value.
    {

        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = (Vector2.left);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = (Vector2.right);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            direction = (Vector2.up);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            direction = (Vector2.down);
        }
    }

    void Move() //Moves the player in a direction, uses Time.deltaTime to maintain consistancy
    {
        if (input) //Ensures the player is allowed to move (not against a wall and refusing to change direction)
        {
            transform.localPosition += (Vector3)(direction * speed * 10) * Time.deltaTime;
        }

    }

    void CheckOrientation() //Rotates Ms-PacMan depending on what direction she is facing, this avoids unnecessary animation switches
    {
        if (direction == (Vector2.left)) 
        {
            orientation = Quaternion.Euler(0, 0, 0); //Assigns the rotation to the orientation variable
        }
        else if (direction == (Vector2.right))
        {
            orientation = Quaternion.Euler(0, -180, 0);
        }
        else if (direction == (Vector2.up))
        {
            orientation = Quaternion.Euler(0, -180, -90);
        }
        else if (direction == (Vector2.down))
        {
            orientation = Quaternion.Euler(0, 0, 90);
        }
        transform.localRotation = orientation; //sets the players rotation to the orientation variable

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!changedDirection) //Checks if the player has changed directions, if they haven't then the input is set to false and the player is stuck
        {
            
            if (lastDirection == (Vector2.left)) //The following four if-else statements check if the player has chosen a different input to the input they were using when colliding with the wall
            {
                if (direction == Vector2.right || direction == Vector2.down || direction == Vector2.up)
                {
                    Validate();
                }
            }
            else if (lastDirection == (Vector2.right))
            {
                if (direction == Vector2.left || direction == Vector2.down || direction == Vector2.up)
                {
                    Validate();
                }
            }
            else if (lastDirection == (Vector2.up))
            {
                if (direction == Vector2.right || direction == Vector2.down || direction == Vector2.left)
                {
                    Validate();
                }
            }
            else if (lastDirection == (Vector2.down))
            {
                if (direction == Vector2.right || direction == Vector2.left || direction == Vector2.up)
                {
                    Validate();
                }
            }
        }

        
    }

    void Validate() //Validates a change in direction and allows movement once again
    {
        input = true;
        changedDirection = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) //At fiirst point of collision
    {
        if (collision.transform.tag.Equals("Wall"))
        {
            if (!changedDirection) //Checks if the player has changed directions, if they haven't then the input is set to false and the player is stuck
            {
                input = false;
            }
        }
        lastDirection = direction; //Maintains a record of the direction the player faced when colliding
        if (collision.transform.tag.Equals("Pellet")) //checks for tag equalling pellet
        {
            pelletsEaten++;
            score += 10;
            scoreText.text = " " + score.ToString();
            Destroy(collision.gameObject);
            pelletEat.Play();
            if (pelletsEaten == 238)
            {
                StartCoroutine(WonGame());
            }
            
        }
        else if (collision.transform.tag.Equals("SuperPellet")) //Otherwise checks for tag equalling "SuperPellet"
        {
            pelletsEaten++;
            score += 50;
            scoreText.text = " " + score.ToString();
            Destroy(collision.gameObject);
            if (pelletsEaten == 238)
            {
                StartCoroutine(WonGame());
            }
        }
        else if (collision.transform.tag.Equals("Enemy"))//Otherwise checks for tag equalling "Enemy"
        {
            StartCoroutine(Died()); //If the player interacts with an enemy, begins the Death coroutine
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //When leaving a 2D collider
    {
        if (collision.transform.tag.Equals("Wall")) //checks if gameobject is tagged "Wall"
        {
            changedDirection = false; //resets changedDirection back to false in preperation of next collision
        }


    }

    IEnumerator Died()
    {
        Time.timeScale = 0; // pause
        LoseMusic.Play(); //Plays the lose music
        float t = 0; //Starts a counter
        while (t < 3f)
        {
            yield return null; //runs the coroutine continuously
            t += Time.unscaledDeltaTime; // returns deltaTime without being multiplied by Time.timeScale
        }
        BlueGhost.transform.position = new Vector3(-39f + 283.4415f, 33 - 72.35378f, 0.5f);
        PurpleGhost.transform.position = new Vector3(29f +283.4415f, 33 - 72.35378f, 0.5f);
        GreenGhost.transform.position = new Vector3(-5f +283.4415f, 33 - 72.35378f, 0.5f);
        RedGhost.transform.position = new Vector3(283.4415f - 5.5f, -72.35378f +85.9f, 0.5f);
        gameObject.transform.position = new Vector3(279, -94, 0.5f); //Resets all the enemies to their intended positions
        if (livesLost == 3) //Checks if the player has lost too many lives
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
        else
        {
            livesLost++;
            Validate();
            Destroy(lives[lives.Length - livesLost]);
            direction = Vector2.zero;
            Time.timeScale = 1;
            BlueGhost.GetComponent<EnemyMovement>().enabled = false; //toggles these scripts to re-invoke them
            BlueGhost.GetComponent<EnemyMovement>().enabled = true;
            GreenGhost.GetComponent<EnemyMovement>().enabled = false; 
            GreenGhost.GetComponent<EnemyMovement>().enabled = true;
            PurpleGhost.GetComponent<EnemyMovement>().enabled = false; 
            PurpleGhost.GetComponent<EnemyMovement>().enabled = true;
        }
        
        

    }

    IEnumerator WonGame()
    {
        
        Time.timeScale = 0; // pause
        WinMusic.Play();
        float t = 0;
        while (t < 7f)
        {
            yield return null; //runs the coroutine continuously
            t += Time.unscaledDeltaTime; // returns deltaTime without being multiplied by Time.timeScale
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    
}
