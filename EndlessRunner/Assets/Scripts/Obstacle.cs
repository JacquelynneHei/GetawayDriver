using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if the player collided with me
        if(other.GetComponent<PlayerController>())
        {
            GameManager.instance.GameOver();
        }
    }
}
