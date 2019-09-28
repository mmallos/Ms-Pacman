using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPath : MonoBehaviour
{
    int changed = 0;
    public GameObject With;
    public GameObject Blinky;
    public GameObject Starring;
    public GameObject MsPacManText;
    public GameObject Purply;
    public GameObject Inky;
    public GameObject Clyde;
    RedMovement[] Path;
    public GameObject Enemy;
    public float Speed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPosition;

    void Start() //Creates path and deactivates a lot of text because they are not ment to appear yet
    {
        Path = GetComponentsInChildren<RedMovement>(); //Creates a path from the RedMovement scripts in children which are connected to the ghosts nodes
        CheckNode();
        Purply.SetActive(false);
        Inky.SetActive(false);
        Clyde.SetActive(false);
        Starring.SetActive(false);
        MsPacManText.SetActive(false);
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
        if (CurrentNode == 3 && changed == 0) //Verifies the Red Ghost has reached it's final node and deactivates it's text while enabling the next ghosts
        {
            ChangeText();
            changed = 1;
        }
        if (CurrentNode == 2)
        {

        }
        if (Input.GetKeyDown("1"))
        {
            Destroy(this.gameObject);
            
        }

    }
    void ChangeText() //Method that deactivates and activates certain elements for the switchover of ghosts
    {
        Blinky.SetActive(false);
        With.SetActive(false);
        Purply.SetActive(true);
    }
}
