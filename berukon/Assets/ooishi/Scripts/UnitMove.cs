using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Vrtical
{
    Up,
    Down
}
public class UnitMove : MonoBehaviour
{
    public Vrtical vrtical;
    private Rigidbody2D rb = null;
    private bool Rotefrag;
    private float rotecount;
    private bool LRfrag;
    private GameObject con;
    private Conveyor conveyor;
    private float angle,an;
    public bool healfrag;
    public float HealTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(vrtical==Vrtical.Up)
        {
            an = 0;
        }else
        {
            an = 180;
        }
        con= transform.root.gameObject;
        conveyor = con.gameObject.GetComponent<Conveyor>();
        rotecount = 720;
        Rotefrag = false;
        LRfrag = true;
        rb = GetComponent<Rigidbody2D>();
        healfrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(healfrag == true)
        {
            HealTime += Time.deltaTime;
            if(2 < HealTime)
            {
                //Debug.Log("ヒールタイムリセット");
                HealTime = 0;
            }
        }
    }
    void Move()
    {
        angle = conveyor.speed * rotecount/800;
        if(LRfrag==true)
        {
            if (vrtical == Vrtical.Up)
            {
                if (conveyor.direction == Direction.Right)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, -1);
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, 1 );
                    }
                }
            }
            else
            {
                if (conveyor.direction == Direction.Right)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, -1);
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, 1 );
                    }
                }
            }

        }
        else
        {
            if (vrtical == Vrtical.Up)
            {
                if (conveyor.direction == Direction.Right)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0,an), angle);
                        //transform.Rotate(0, 0, -1 );
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, 1 );
                    }
                }
            }else
            {
                if (conveyor.direction == Direction.Right)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, -1);
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount < 360)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, 1);
                    }
                }
            }
        }
        if(Rotefrag==true)
            rb.velocity = new Vector2(0, 0);
        if(rotecount>60)
        {
            Rotefrag = false;
        }
        rotecount+=1* conveyor.speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            healfrag = true;
           
        }
        if (collision.tag=="wall")
        {
            angle = 0;
            rotecount = 0;
            Rotefrag = true;
            if (conveyor.direction == Direction.Right)
                an += 180.1f;
            if (conveyor.direction == Direction.Left)
                an -=180.1f;
            if (LRfrag == true)
            {
                LRfrag = false;
            }
            else
            {
                LRfrag = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            //falseが上の状態
            healfrag = false;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Heal")
        {

        }
    }
}
