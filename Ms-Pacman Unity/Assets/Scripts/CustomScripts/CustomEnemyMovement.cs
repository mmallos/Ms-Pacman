using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEnemyMovement : MonoBehaviour
{
    private float speed;
    public Vector3 direction;
    private int rand = 0;
    private int lastDirection = 0;
    // Start is called before the first frame update
    void Start() //Opening script sets start points for different ghosts through the use of an Invoke clause depending on their names.
    {
        speed = PlayerPrefs.GetFloat("ESpeed");
        rand = (Random.Range(0, 4)); //Selects randon digit in the range 0-3 (inclusive)
        SelectDirection();
        if (PlayerPrefs.GetInt("enemies") < 4)
        {
            if (transform.name.Equals("BlueGhost"))
            {
                Destroy(gameObject);
            }
            if (PlayerPrefs.GetInt("enemies") < 3)
            {
                if (transform.name.Equals("PurpleGhost"))
                {
                    Destroy(gameObject);
                }
                if (PlayerPrefs.GetInt("enemies") < 2)
                {
                    if (transform.name.Equals("GreenGhost"))
                    {
                        Destroy(gameObject);
                    }
                    if (PlayerPrefs.GetInt("enemies") < 1)
                    {
                        if (transform.name.Equals("RedGhost"))
                        {
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
        if (transform.name.Equals("GreenGhost"))
        {
            speed = 0f;
            Invoke("AllowMove", 5);
        }
        if (transform.name.Equals("PurpleGhost"))
        {
            speed = 0f;
            Invoke("AllowMove", 10);
        }
        if (transform.name.Equals("BlueGhost"))
        {
            speed = 0f;
            Invoke("AllowMove", 15);
        }
    }
    private void OnEnable() //Does the same as the opening section except for when the script is enabled. Allows for the ghosts to be on timeout when the player loses a life
    {
        if (transform.name.Equals("GreenGhost"))
        {
            speed = 0f;
            Invoke("AllowMove", 5);
        }
        if (transform.name.Equals("PurpleGhost"))
        {
            speed = 0f;
            Invoke("AllowMove", 10);
        }
        if (transform.name.Equals("BlueGhost"))
        {
            speed = 0f;
            Invoke("AllowMove", 15);
        }
    }
    void AllowMove() //Sets the speed to the default speed.
    {
        speed = PlayerPrefs.GetFloat("ESpeed");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * .00001f);
        transform.position += direction * speed * Time.deltaTime; //Moves the enemy in the direction it is facing with respect to its speed and the time since the last frame

    }

    void SelectDirection() //Sets the direction for the enemy based on a random value generated from the 'Random' class
    {
        if (rand == 0) //checks the value of random and sets the direction accordingly
        {
            direction = transform.up;
        }
        else if (rand == 1)
        {
            direction = -transform.up;
        }
        else if (rand == 2)
        {
            direction = -transform.right;
        }

        else if (rand == 3)
        {
            direction = transform.right;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //Every collision the enemy makes with a wall will force a new random value to be generated.
    {
        if (collision.transform.tag.Equals("Wall")) //Checks the collisions tag ensuring it is "wall"
        {
            lastDirection = rand;
            rand = (Random.Range(0, 4));
            if (lastDirection == rand) //This section also saves the last direction the ghost was travelling and compares it to its new direction. If these directions are the same it will go back the way it came.
            {
                if (lastDirection == 2)
                {
                    rand = 3;
                }
                else if (lastDirection == 3)
                {
                    rand = 2;
                }
                else if (lastDirection == 0)
                {
                    rand = 1;
                }
                else if (lastDirection == 1)
                {
                    rand = 0;
                }
            }
            SelectDirection();
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1);
        }

    }
}
