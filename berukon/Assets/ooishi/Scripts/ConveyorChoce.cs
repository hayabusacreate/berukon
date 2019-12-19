using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorChoce : MonoBehaviour
{
    public Conveyor[] conveyors;
    private int conveyorCount;
    // Start is called before the first frame update
    void Start()
    {
        conveyorCount = 0;
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
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            conveyorCount++;
            if(conveyorCount>=conveyors.Length)
            {
                conveyorCount = conveyors.Length-1;
            }
            for (int i = 0; i < conveyors.Length; i++)
            {
                if(conveyorCount==i)
                {
                    conveyors[i].moveflag = true;
                }else
                {
                    conveyors[i].moveflag = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            conveyorCount--;
            if (conveyorCount < 0)
            {
                conveyorCount = 0;
            }
            for (int i = 0; i < conveyors.Length-1; i++)
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
