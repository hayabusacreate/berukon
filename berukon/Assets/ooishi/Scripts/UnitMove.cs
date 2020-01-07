using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float angle, an;
    public bool healfrag;
    public bool Deathflag;
    public float HealTime = 0;
    public float cooltime = 2;
    public int UnityLife;
    public Slider _slider;
    private float rote;
    // Start is called before the first frame update
    void Start()
    {
        con = transform.root.gameObject;
        conveyor = con.gameObject.GetComponent<Conveyor>();
        rotecount = 720;
        Rotefrag = false;
        LRfrag = true;
        rb = GetComponent<Rigidbody2D>();
        healfrag = false;
        _slider.maxValue = UnityLife;
        if (vrtical == Vrtical.Up)
        {
            if (conveyor.direction == Direction.Right)
            {
                an = 0.1f;
            }
            if (conveyor.direction == Direction.Left)
            {
                an = -0.1f;
            }
        }
        else
        {
            if (conveyor.direction == Direction.Right)
            {
                an = 180.1f;
            }
            if (conveyor.direction == Direction.Left)
            {
                an = 179.9f;
            }

        }
        Deathflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Deathflag)
        {
            if(UnityLife>=_slider.maxValue-1)
            {
                Deathflag = false;
            }
        }
        else
        {
            if(UnityLife<=0)
            {
                Deathflag = true;
            }
        }
        if(UnityLife<=0)
        {
            UnityLife = 0;
        }
        // HPゲージに値を設定
        _slider.value = UnityLife;
        Move();
        if (healfrag == true && UnityLife <= _slider.maxValue)
        {
            HealTime += Time.deltaTime;
            if (cooltime < HealTime)
            {
               
                    //Debug.Log("ヒールタイムリセット");
                    UnitLife_Manager(1);
                    HealTime = 0;
                
            }
        }
        if (healfrag == false)
        {
            HealTime = 0;
        }

    }
    void Move()
    {
        //angle = conveyor.speed * rotecount/2;
        if (LRfrag == true)
        {
            if (vrtical == Vrtical.Up)
            {
                if (conveyor.direction == Direction.Right)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount <= 180)
                    {
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        transform.Rotate(0, 0, -rote);
                        //transform.Rotate(0, 0, -1);
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount <=180)
                    {
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        transform.Rotate(0, 0, rote);
                        //transform.Rotate(0, 0, 1 );
                    }
                }
            }
            else
            {
                if (conveyor.direction == Direction.Right)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount <= 180)
                    {
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, -1);
                        transform.Rotate(0, 0, -rote);
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount <= 180)
                    {
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        transform.Rotate(0, 0, rote);
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
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount <= 180)
                    {
                        transform.Rotate(0, 0, -rote);
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, -1 );
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(-conveyor.speed, 0);
                    if (rotecount <= 180)
                    {
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        transform.Rotate(0, 0, rote);
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
                    if (rotecount <= 180)
                    {
                        transform.Rotate(0, 0, -rote);
                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                        //transform.Rotate(0, 0, -1);
                    }
                }
                if (conveyor.direction == Direction.Left)
                {
                    if (Rotefrag == false)
                        rb.velocity = new Vector2(conveyor.speed, 0);
                    if (rotecount <= 180)
                    {
                        //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, 0, an), angle);
                        // 回転速度分回す
                        transform.Rotate(0, 0, rote);
                        //transform.Rotate(0, 0, 1);
                    }
                }
            }
        }
        if (Rotefrag == true)
            rb.velocity = new Vector2(0, 0);
        if (rotecount >= 180)
        {
            Rotefrag = false;
        }
        rotecount += 1 * conveyor.speed;
        rote = 1 * conveyor.speed;
        if (rotecount>180)
        {
            rote -= rotecount - 180;
            rotecount = 180;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            healfrag = true;

        }
        if (collision.tag == "wall")
        {
            angle = 0;
            rotecount = 0;
            Rotefrag = true;
            if (conveyor.direction == Direction.Right)
                an += 180.0f;
            if (conveyor.direction == Direction.Left)
                an -= 180.0f;
            if (LRfrag == true)
            {
                LRfrag = false;
            }
            else
            {
                LRfrag = true;
            }
        }
        if (collision.gameObject.tag == "EnemyBullet"&&!healfrag)
        {
            if(!Deathflag)
            UnitLife_Manager(-1);
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
    private void UnitLife_Manager(int Life)
    {
        UnityLife = UnityLife + Life;
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Heal")
    //    {

    //    }
    //}
}
