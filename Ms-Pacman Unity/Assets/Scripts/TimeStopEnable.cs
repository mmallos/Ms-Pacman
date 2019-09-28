using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Super").Equals("Super Pellet"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
