using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Player")]
    public PlayerController player;

    [Header("Lanes")]
    public float leftLane;
    public float centerLane;
    public float rightLane;

    //movement variables, these are set on start to be the same as the players
    private float xSpeed;
    private float speed;

    private void Start()
    {
        //set the speed and xspeed equal to the players
        speed = player.speed;
        xSpeed = player.xSpeed;
    }

    void Update()
    {
        Follow();

    }

    public void Follow()
    {
        speed = player.speed;

        Vector3 myPos = transform.position;
        myPos.z += speed * Time.deltaTime;
        transform.position = myPos;
    }

    public void MoveOnX(float moveTo)
    {
        float move = 0;

        if(moveTo == player.leftLane)
        {
            move = leftLane;
        }
        else if(moveTo == player.centerLane)
        {
            move = centerLane;
        }
        else
        {
            move = rightLane;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(move, transform.position.y, transform.position.z), xSpeed * Time.deltaTime);
    }

    
}
