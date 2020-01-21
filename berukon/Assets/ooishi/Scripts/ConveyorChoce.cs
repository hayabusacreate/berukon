using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SelectSpeed
{
    Tap,
    State,
    Rotat,
    hayabusa,
}
public class ConveyorChoce : MonoBehaviour
{
    public SelectSpeed selectSpeed;
    public Conveyor[] conveyors;
    private int conveyorCount;
    public bool right=true, left=true, down=true;
    // Start is called before the first frame update
    void Start()
    {
        conveyorCount = 1;
        for (int i = 0; i < conveyors.Length - 1; i++)
        {
            if (conveyorCount == i)
            {
                conveyors[i].moveflag = true;
            }
            else
            {
                conveyors[i].moveflag = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Choce();
    }
    private void Choce()
    {
        if (selectSpeed == SelectSpeed.hayabusa|| selectSpeed == SelectSpeed.State)
        {
            if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown("joystick button 1"))&&left)
            {
                conveyorCount = 0;
            }
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("joystick button 0"))&&down)
            {
                conveyorCount = 1;
            }
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("joystick button 2"))&&right)
            {
                conveyorCount = 2;
            }
            for (int i = 0; i < conveyors.Length; i++)
            {
                if (conveyorCount == i)
                {
                    conveyors[i].moveflag = true;
                }
                else
                {
                    conveyors[i].moveflag = false;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("joystick button 5"))
            {
                conveyorCount++;
                if (conveyorCount >= conveyors.Length)
                {
                    conveyorCount = 0;
                }
                for (int i = 0; i < conveyors.Length; i++)
                {
                    if (conveyorCount == i)
                    {
                        conveyors[i].moveflag = true;
                    }
                    else
                    {
                        conveyors[i].moveflag = false;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("joystick button 4"))
            {
                conveyorCount--;
                if (conveyorCount < 0)
                {
                    conveyorCount = conveyors.Length - 1;
                }
                for (int i = 0; i < conveyors.Length; i++)
                {
                    if (conveyorCount == i)
                    {
                        conveyors[i].moveflag = true;
                    }
                    else
                    {
                        conveyors[i].moveflag = false;
                    }
                }
            }
        }

    }
}
