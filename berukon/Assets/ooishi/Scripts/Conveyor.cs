using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject up, down;
    public Slider _slider;
    private float speedup;
    // Start is called before the first frame update
    void Start()
    {
        speedup = 0.05f;
        conveyor = GameObject.Find("BerukonChoce").GetComponent<ConveyorChoce>();
        speed = nomalspeed;
        up.SetActive(false);
        down.SetActive(false);
        _slider.maxValue = maxspeed;
        _slider.minValue = minspeed-0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
    }
    void ChangeSpeed()
    {
        _slider.value = speed;
        if (conveyor.selectSpeed == SelectSpeed.Tap)
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 0")) && moveflag)
            {
                up.SetActive(true);
                speed -= speedup;
                if (speed < minspeed)
                {
                    speed = minspeed;
                }
            }
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown("joystick button 1")) && moveflag)
            {
                down.SetActive(true);
                speed += speedup;
                if (speed > maxspeed)
                {
                    speed = maxspeed;
                }
            }
        }
        if (conveyor.selectSpeed == SelectSpeed.State)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Vertical") <= -0.8f || Input.GetKey("joystick button 4")) && moveflag)
            {
                speed -= speedup;
                up.SetActive(false);
                down.SetActive(true);
                if (speed < minspeed)
                {
                    speed = minspeed;
                }
            }else
            if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Vertical") >= 0.8f|| Input.GetKey("joystick button 5")) && moveflag)
            {
                speed += speedup;
                down.SetActive(false);
                up.SetActive(true);
                if (speed > maxspeed)
                {
                    speed = maxspeed;
                }
            }else
            {
                down.SetActive(false);
                up.SetActive(false);
            }
            if(!moveflag)
            {
                down.SetActive(false);
                up.SetActive(false);
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
                    speed += speedup;
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
                            speed -= speedup;
                        }
                        else
                        {
                            speed += speedup;
                        }
                    }else
                    {
                        if (upDown == UpDown.Up)
                        {
                            speed += speedup;
                        }
                        else
                        {
                            speed -= speedup;
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
                            speed += speedup;
                        }
                        else
                        {
                            speed -= speedup;
                        }
                    }
                    else
                    {
                        if (upDown == UpDown.Up)
                        {
                            speed -= speedup;
                        }
                        else
                        {
                            speed += speedup;
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
