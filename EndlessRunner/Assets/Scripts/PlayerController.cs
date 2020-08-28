using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xSpeed;
    public float leftLane;
    public float rightLane;
    public float centerLane;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private CameraController cameraController;

    
    private float xPos;
    private bool moveOnX = false;

    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        HandleInput();
        Move();

        if(moveOnX == true)
        {
            MoveX(xPos);
        }
    }

    void Move()
    {
        Vector3 myPos = transform.position;
        myPos.z += speed * Time.deltaTime;
        transform.position = myPos;
    }

    void MoveX(float moveTo)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveTo, transform.position.y, transform.position.z), xSpeed * Time.deltaTime);

        cameraController.MoveOnX(moveTo);

        if(transform.position.x == moveTo)
        {
            moveOnX = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;

        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;

            if (endPosition.x < startPosition.x)
            {
                //swipe left
                if (transform.position.x == rightLane)
                {
                    xPos = centerLane;
                    moveOnX = true;
                }
                else if (transform.position.x == centerLane)
                {
                    xPos = leftLane;
                    moveOnX = true;
                }
                else
                {
                    //the player cannot move left any more
                }

            }

            if (endPosition.x > startPosition.x)
            {
                //swipe right
                if (transform.position.x == leftLane)
                {
                    xPos = centerLane;
                    moveOnX = true;
                }
                else if (transform.position.x == centerLane)
                {
                    xPos = rightLane;
                    moveOnX = true;
                }
                else
                {
                    //the player cannot move right any more
                }
            }
        }
    }


}
