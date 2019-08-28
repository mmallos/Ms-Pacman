using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsPacman : MonoBehaviour
{
    Quaternion orientation = Quaternion.Euler(0, 0, 0);
    public float speed = 10.0f;
    private Vector2 direction = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Move();
        CheckOrientation();
    }

    void Movement()
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

    void Move()
    {
        transform.localPosition += (Vector3)(direction * speed * 10) * Time.deltaTime;
    }

    void CheckOrientation()
    {
        if (direction == (Vector2.left))
        {
            orientation = Quaternion.Euler(0, 0, 0);
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
        transform.localRotation = orientation;

    }
}
