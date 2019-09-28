using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePath : MonoBehaviour
{
    int changed = 0;
    public GameObject Purply;
    public GameObject Inky;
    PurpleMovement[] Path;
    public GameObject Enemy;
    public float Speed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPosition;
    //See RedPath for commenting
    void Start()
    {
        Path = GetComponentsInChildren<PurpleMovement>(); //Creates a path from the RedMovement scripts in children which are connected to the ghosts nodes
        CheckNode();
    }

    void CheckNode()
    {
        if (CurrentNode < Path.Length - 1)
            Timer = 0;
        CurrentPosition = Path[CurrentNode].transform.position;
    }
    void DrawLine()
    {
        for (int i = 0; i < Path.Length; i++)
        {
            if (i < Path.Length - 1)
            {
                Debug.DrawLine(Path[i].transform.position, Path[i + 1].transform.position, Color.blue);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Destroy(this.gameObject);
        }
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
        if (CurrentNode == 3 && changed == 0)
        {
            Inky.SetActive(true);
            Purply.SetActive(false);
            changed = 1;

        }
    }
}

