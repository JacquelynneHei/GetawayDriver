using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boost;
    public float count;
    private float timer;   

    bool countDown;

    PlayerController player;
   

    private void OnTriggerEnter(Collider other)
    {
        //if the player entered the trigger
        if(other.GetComponent<PlayerController>())
        {
            //get their player controller 
            player = other.GetComponent<PlayerController>();

            //set their speed times 2
            player.speed *= boost;

            //start the countdown
            timer = count;
            countDown = true;
        }
    }

    private void Update()
    {
        //if countdown is true
        if(countDown == true)
        {
            //subtract time from the timer
            timer -= Time.deltaTime;
        }

        //if the timer has run out
        if(timer <= 0)
        {
            if(player != null)
            {
                player.speed /= boost;
                countDown = false;
                timer = count;
            }
        }
    }
}
