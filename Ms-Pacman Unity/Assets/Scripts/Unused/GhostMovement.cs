using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 10.0f;
    //private System.Random random = new System.Random;
    public Vector2 direction = Vector2.up;
    private int rand = 0;

    // Start is called before the first frame update
    void Start()
    {
        rand = (Random.Range(0,3));
        SelectDirection();

        direction = Vector2.down;   

    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += (Vector3)(direction * speed * 10) * Time.deltaTime;
        transform.localPosition = Vector2.MoveTowards(transform.position, transform.up, Time.deltaTime * 50f);

    }
    void SelectDirection()
    {
        if (rand == 0)
        {
            direction = Vector2.up;
        }
        else if (rand == 1)
        {
            direction = Vector2.down;
        }
        else if (rand == 2)
        {
            direction = Vector2.left;
        }

        else if (rand == 3)
        {
            direction = Vector2.right;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction = Vector2.up;
        //lastDirection = rand;
        //rand = (Random.Range(0, 3));
        SelectDirection();
        //Debug.Log(direction);
    }
}
