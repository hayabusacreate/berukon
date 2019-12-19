﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Right,
    Left,
}
public class Conveyor : MonoBehaviour
{
    public Direction direction;
    public float maxspeed,nomalspeed,minspeed;
    public float speed;
    public bool moveflag;
    // Start is called before the first frame update
    void Start()
    {
        speed = nomalspeed;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
    }
    void ChangeSpeed()
    {
        if(Input.GetKeyDown(KeyCode.A)&&moveflag)
        {
            speed -= 0.1f;
            if (speed < minspeed)
            {
                speed = minspeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && moveflag)
        {
            speed += 0.1f;
            if(speed>maxspeed)
            {
                speed = maxspeed;
            }
        }
    }
}
