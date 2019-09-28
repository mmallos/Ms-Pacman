using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsPacManPath : MonoBehaviour
{
    MsPacmanMovement[] Path;
    public GameObject Enemy;
    public float Speed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPosition;
    // Start is called before the first frame update
    void Start()
    {
        Path = GetComponentsInChildren<MsPacmanMovement>();
        CheckNode();
    }

    //Update is called once per frame


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

