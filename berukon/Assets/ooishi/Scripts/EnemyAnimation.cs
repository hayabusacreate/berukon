using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float y;
    private float count;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if(flag)
        {
            count++;
            if (count > y)
            {
                flag = false;
            }
        }
        else
        {
            count--;
            if (count < -y)
            {
                flag = true;
            }
        }

        gameObject.transform.position=Vector3.Lerp(transform.position,new Vector3(transform.position.x,transform.position.y+count/100,transform.position.z),1) ;
    }
}
