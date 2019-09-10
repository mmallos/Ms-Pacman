using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class Game : MonoBehaviour
{
    public static int boardWidth = 28;
    public static int boardheight = 36;

    public GameObject[,] board = new GameObject[boardWidth, boardheight];
    // Start is called before the first frame update
    void Start()
    {
        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach (GameObject o in objects)
        {
            Vector2 pos = o.transform.position;

            if (o.name != "MsPacman")
            {
                board[(int)pos.x, (int)pos.y] = o;
            }
            else
            {
                Debug.Log("MsPacman is at: " + pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
