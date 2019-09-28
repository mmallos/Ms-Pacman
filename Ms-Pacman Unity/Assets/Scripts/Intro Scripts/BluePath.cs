using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePath : MonoBehaviour
{
    int changed = 0;
    public GameObject Inky;
    public GameObject Clyde;
    BlueMovement[] Path;
    public GameObject Enemy;
    public float Speed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPosition;

    void Start()
    {
        Path = GetComponentsInChildren<BlueMovement>(); //Creates a path from the BlueMovement scripts in children which are connected to the ghosts nodes
        CheckNode();
    }

    void CheckNode() //Checks if the ghosts has reached the next node and then assigns the following point for the ghost to travel to
    {
        if (CurrentNode < Path.Length - 1)
            Timer = 0;
        CurrentPosition = Path[CurrentNode].transform.position;
    }

    void Update()
    {
        Timer = Speed;
        if (Enemy.transform.position != CurrentPosition)
        {
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, CurrentPosition, Timer);
        }

        else
        {
            if (CurrentNode < Path.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }

        if (Input.GetKeyDown("1")) //Safely removes this gameObject and what it is connected to so they don't pop up in the start game sreen
        {
            Destroy(this.gameObject); 
        }

        if (CurrentNode == 3 && changed == 0)
        { //Verifies the Blue Ghost has reached it's final node and deactivates it's text while enabling the next ghosts
            Clyde.SetActive(true);
            Inky.SetActive(false);
            changed = 1; //Sets a changed variable so it doesn't continuously deactivate these variables
        }
    }
}

