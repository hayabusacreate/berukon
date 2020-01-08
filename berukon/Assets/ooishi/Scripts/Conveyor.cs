using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Right,
    Left,
}
public enum UpDown
{
    Up,
    Down
}
public class Conveyor : MonoBehaviour
{
    public Direction direction;
    private ConveyorChoce conveyor;
    public float maxspeed, nomalspeed, minspeed;
    public float speed;
    public bool moveflag;
    private float r, g, b;
    private bool x, y, x2, y2;
    public UpDown upDown;
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
        if (conveyor.selectSpeed == SelectSpeed.Tap)
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 0")) && moveflag)
            {
                speed -= 0.1f;
                if (speed < minspeed)
                {
                    speed = minspeed;
                }
            }
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown("joystick button 1")) && moveflag)
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
            if ((Input.GetKey(KeyCode.A) || Input.GetKey("joystick button 0")) && moveflag)
            {
                speed -= 0.1f;
                if (speed < minspeed)
                {
                    speed = minspeed;
                }
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey("joystick button 1")) && moveflag)
            {
                speed += 0.1f;
                if (speed > maxspeed)
                {
                    speed = maxspeed;
                }
            }
        }
        if (conveyor.selectSpeed == SelectSpeed.Rotat)
        {
            if (moveflag)
            {
                if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Vertical") == 1)
                {
                    x = true;
                }
                if (Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == -1)
                {
                    y = true;
                }
                if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                {
                    x = false;
                    y = false;
                }
                if (x && y)
                {
                    speed += 0.1f;
                    if (speed > maxspeed)
                    {
                        speed = maxspeed;
                    }
                    x = false;
                    y = false;
                }
                if (Input.GetAxis("Horizontal2") == 1 || Input.GetAxis("Vertical2") == 1)
                {
                    x2 = true;
                }
                if (Input.GetAxis("Horizontal2") == -1 || Input.GetAxis("Vertical2") == -1)
                {
                    y2 = true;
                }
                if (Input.GetAxis("Horizontal2") == 0 && Input.GetAxis("Vertical2") == 0)
                {
                    x2 = false;
                    y2 = false;
                }
                if (x2 && y2)
                {
                    speed -= 0.1f;
                    if (speed < minspeed)
                    {
                        speed = minspeed;
                    }
                    x2 = false;
                    y2 = false;
                }
            }
        }
        if (conveyor.selectSpeed == SelectSpeed.hayabusa)
        {
            if (moveflag)
            {
                if (Input.GetAxis("Horizontal") >0)
                {
                    if(direction==Direction.Right)
                    {
                        if(upDown==UpDown.Up)
                        {
                            speed -= 0.1f;
                        }
                        else
                        {
                            speed += 0.1f;
                        }
                    }else
                    {
                        if (upDown == UpDown.Up)
                        {
                            speed += 0.1f;
                        }
                        else
                        {
                            speed -= 0.1f;
                        }
                    }
                }
                else
                if (Input.GetAxis("Horizontal") <0)
                {
                    if (direction == Direction.Right)
                    {
                        if (upDown == UpDown.Up)
                        {
                            speed += 0.1f;
                        }
                        else
                        {
                            speed -= 0.1f;
                        }
                    }
                    else
                    {
                        if (upDown == UpDown.Up)
                        {
                            speed -= 0.1f;
                        }
                        else
                        {
                            speed += 0.1f;
                        }
                    }
                }
                if (speed < minspeed)
                {
                    speed = minspeed;
                }
                if (speed > maxspeed)
                {
                    speed = maxspeed;
                }
            }

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (direction == Direction.Right)
            {
                collision.gameObject.GetComponent<EnemyMove>().speed -= speed;
            }
            if (direction == Direction.Left)
            {
                collision.gameObject.GetComponent<EnemyMove>().speed += speed;
            }
        }
    }
}
