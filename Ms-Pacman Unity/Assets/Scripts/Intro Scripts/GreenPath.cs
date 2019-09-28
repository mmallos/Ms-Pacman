using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPath : MonoBehaviour
{
    GreenMovement[] Path;
    public GameObject clyde;
    public GameObject Starring;
    public GameObject MsPacMan;
    int changed = 0;
    public GameObject Enemy;
    public float Speed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPosition;

    void Start()
    {
        Path = GetComponentsInChildren<GreenMovement>();
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
        if (CurrentNode == 3 && changed == 0) //Method that deactivates and activates certain elements for the switchover of ghosts
        {
            Starring.SetActive(true);
            MsPacMan.SetActive(true);
            clyde.SetActive(false);
            changed = 1; //Sets a changed variable so it doesn't continuously deactivate these variables
        }
        if (Input.GetKeyDown("1"))
        {
            Starring.SetActive(false);
            MsPacMan.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}

