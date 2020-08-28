using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModifier : Pickup
{
    public float countdownTime;

    MeshRenderer child;
    float timer = 1f;
    bool isCollected;

    private void Start()
    {
        child = GetComponentInChildren<MeshRenderer>();
    }
    private void Update()
    {
        //if this pick has been collected by the player
        if(isCollected)
        {
            //count down to 0
            timer -= Time.deltaTime;
        }

        //if the timer is less than or equal to 0
        if(timer <= 0f)
        {
            //set is collected false
            isCollected = false;

            //change the score multiply back to what it was previously
            GameManager.instance.score.multiplier /= 2;

            //set the timer to one so this if statement isn't triggered
            timer = 1f;

            //destroy the game object when done
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the player hit me
        if(other.GetComponent<PlayerController>())
        {
            //times the score multiplier by 2
            GameManager.instance.score.multiplier *= 2;

            //set the child inactive so the player can't see the gameobject
            child.enabled = false;

            //set the count down timer 
            timer = countdownTime;

            //set the item as collected
            isCollected = true;
        }
    }
}
