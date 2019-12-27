using System.Collections;
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
    private  ConveyorChoce conveyor;
    public float maxspeed,nomalspeed,minspeed;
    public float speed;
    public bool moveflag;
    private float r, g, b;
    // Start is called before the first frame update
    void Start()
    {
        conveyor = GameObject.Find("BerukonChoce").GetComponent<ConveyorChoce>();
        speed = nomalspeed;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
    }
    void ChangeSpeed()
    {
        if(conveyor.selectSpeed==SelectSpeed.Tap)
        {
            if (Input.GetKeyDown(KeyCode.A) && moveflag)
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
                if (speed > maxspeed)
                {
                    speed = maxspeed;
                }
            }
        }
        if (conveyor.selectSpeed == SelectSpeed.State)
        {
            if (Input.GetKey(KeyCode.A) && moveflag)
            {
                speed -= 0.1f;
                if (speed < minspeed)
                {
                    speed = minspeed;
                }
            }
            if (Input.GetKey(KeyCode.D) && moveflag)
            {
                speed += 0.1f;
                if (speed > maxspeed)
                {
                    speed = maxspeed;
                }
            }
        }
    }
}
