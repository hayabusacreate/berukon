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
    public int maxspeed = 5, nomalspeed = 3, minspeed = 1;
    public float speed;
    public bool moveflag;
    private float r, g, b;
    private bool x, y, x2, y2;
    public UpDown upDown;
    public GameObject up, down;
    public Slider _slider;
    private float speedup;
    //スマホ
    private Touch touch;
    private Vector3 spos, nowpos;
    private bool touchflag;
    // Start is called before the first frame update
    void Start()
    {
        speedup = 0.5f;
        conveyor = GameObject.Find("BerukonChoce").GetComponent<ConveyorChoce>();
        speed = (float)nomalspeed / 2;
        up.SetActive(false);
        down.SetActive(false);
        _slider.maxValue = maxspeed;
        _slider.minValue = minspeed - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
    }
    void ChangeSpeed()
    {
        if (Input.touchCount > 0&&moveflag)
        {
            touch = Input.GetTouch(0);
            if (!touchflag)
            {
                touchflag = true;
                spos = touch.position;
            }
            nowpos = touch.position;
            _slider.value = speed;
            if(spos.x-nowpos.x>0)
            {
                speed -= Vector3.Distance(spos, nowpos)/500;
                spos = nowpos;
            }
            if (spos.x - nowpos.x < 0)
            {
                speed += Vector3.Distance(spos, nowpos)/500;
                spos = nowpos;
            }
            if (Vector3.Distance(spos, nowpos) < 0)
            {
                up.SetActive(false);
                down.SetActive(true);
            }
            else
                if (Vector3.Distance(spos, nowpos) > 0)
            {
                down.SetActive(false);
                up.SetActive(true);
            }
            else
            if (!moveflag)
            {
                down.SetActive(false);
                up.SetActive(false);
            }
            if (speed < 0.5f)
            {
                speed = 0.5f;
            }
            if (speed > maxspeed)
            {
                speed = maxspeed;
            }
        }
        else
        {
            touchflag = false;
            spos = new Vector3(0, 0, 0);
            nowpos = new Vector3(0, 0, 0);

            _slider.value = speed;
            if (conveyor.selectSpeed == SelectSpeed.Tap)
            {
                if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 0")) && moveflag)
                {
                    up.SetActive(true);
                    speed -= speedup;
                    if (speed < 0.5f)
                    {
                        speed = 0.5f;
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

                if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Vertical") <= -0.8f || Input.GetKeyDown("joystick button 4")) && moveflag)
                {
                    speed -= speedup;
                    up.SetActive(false);
                    down.SetActive(true);
                    if (speed < 0.5f)
                    {
                        speed = 0.5f;
                    }
                }
                else
                if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Vertical") >= 0.8f || Input.GetKeyDown("joystick button 5")) && moveflag)
                {
                    speed += speedup;
                    down.SetActive(false);
                    up.SetActive(true);
                }
                else
                {
                    down.SetActive(false);
                    up.SetActive(false);
                }
                if (!moveflag)
                {
                    down.SetActive(false);
                    up.SetActive(false);
                }

                if (speed > maxspeed)
                {
                    speed = maxspeed;
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
                    if (Input.GetKeyDown("joystick button 5"))
                    {
                        if (direction == Direction.Right)
                        {
                            if (upDown == UpDown.Up)
                            {
                                speed -= 0.5f;
                            }
                            else
                            {
                                speed += 0.5f;
                            }
                        }
                        else
                        {
                            if (upDown == UpDown.Up)
                            {
                                speed += 0.5f;
                            }
                            else
                            {
                                speed -= 0.5f;
                            }
                        }
                    }
                    else
                    if (Input.GetKeyDown("joystick button 4"))
                    {
                        if (direction == Direction.Right)
                        {
                            if (upDown == UpDown.Up)
                            {
                                speed += 0.5f;
                            }
                            else
                            {
                                speed -= 0.5f;
                            }
                        }
                        else
                        {
                            if (upDown == UpDown.Up)
                            {
                                speed -= 0.5f;
                            }
                            else
                            {
                                speed += 0.5f;
                            }
                        }
                    }
                    if (speed < 0.5f)
                    {
                        speed = 0.5f;
                    }
                    if (speed > maxspeed)
                    {
                        speed = maxspeed;
                    }
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
