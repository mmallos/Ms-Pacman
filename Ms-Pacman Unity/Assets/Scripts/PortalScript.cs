using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject outPortal;

    private void OnTriggerEnter2D(Collider2D collision) //This portal registers collisions from any gameobject and sets their position to an offset of the outPortal gameobject
    {
        collision.transform.SetPositionAndRotation(outPortal.transform.position, collision.transform.rotation);
        if (gameObject.tag.Equals("LeftPortal")) //The portal checks if the tag is for a left or right portal and offsets them accordingly so they don't immediately collide with another portal.
        {
            collision.transform.position = new Vector3(collision.transform.position.x - 30, collision.transform.position.y, collision.transform.position.z);
        }
        else
        {
            collision.transform.position = new Vector3(collision.transform.position.x + 30, collision.transform.position.y, collision.transform.position.z);
        }
    }
}
