using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopEnable : MonoBehaviour
{
    void Start() //Gets the String created from the custom menu and destroys the timestops if the player has selected the super pellet special.
    {
        if (PlayerPrefs.GetString("Super").Equals("Super Pellet"))
        {
            Destroy(gameObject);
        }
    }
}
