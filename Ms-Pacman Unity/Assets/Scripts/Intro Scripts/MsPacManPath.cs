using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//See RedPath for commenting
public class MsPacManPath : MonoBehaviour
{
    MsPacmanMovement[] Path;
    public GameObject Enemy;
    public float Speed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPosition;

    void Start()
    {
        Path = GetComponentsInChildren<MsPacmanMovement>();
        CheckNode();
    }

    void CheckNode()
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
        if (Input.GetKeyDown("1"))
        {
            Destroy(this.gameObject);
        }
    }
}

