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
    public GameObject healobj, deathobj;
    public SpriteRenderer unit;
    public SpriteRenderer uni;
    public GameObject Max, Warnig;
    public GameObject maxpos;
    // Start is called before the first frame update
    void Start()
    {
        healobj.SetActive(false);
        deathobj.SetActive(false);

        con = transform.root.gameObject;
        conveyor = con.gameObject.GetComponent<Conveyor>();
        rotecount = 720;
        Rotefrag = false;
        LRfrag = true;
        rb = GetComponent<Rigidbody2D>();
        healfrag = false;
        _slider.maxValue = UnityLife;
        if (conveyor.upDown == UpDown.Up)
        {
            if (vrtical == Vrtical.Up)
            {
                if (conveyor.direction == Direction.Right)
                {
                    LRfrag = false;
                }
                if (conveyor.direction == Direction.Left)
                {
                    LRfrag = true;
                }
            }
            else
            {
                if (conveyor.direction == Direction.Right)
                {
                    LRfrag = true;
                }
                if (conveyor.direction == Direction.Left)
                {
                    LRfrag = false;
                }
            }

        }
        else
        {
            if (vrtical == Vrtical.Up)
            {
                if (conveyor.direction == Direction.Right)
                {
                    LRfrag = true;
                }
                if (conveyor.direction == Direction.Left)
                {
                    LRfrag = false;
                }
            }
            else
            {
                if (conveyor.direction == Direction.Right)
                {
                    LRfrag = false;
                }
                if (conveyor.direction == Direction.Left)
                {
                    LRfrag = true;
                }
            }
        }



        Deathflag = false;
        Warnig.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Deathflag)
        {
            if (UnityLife >= _slider.maxValue - 1)
            {
                Deathflag = false;
                deathobj.SetActive(false);
                uni.color = new Color32(255, 255, 255, 255);
                unit.color = new Color32(255, 255, 255, 255);
                GameObject obj = Instantiate(Max, maxpos.transform.position, transform.rotation);
                obj.transform.parent = transform;
            }
        }
        else
        {
            if (UnityLife <= 0)
            {
                Deathflag = true;
                deathobj.SetActive(true);
                uni.color = new Color32(170, 170, 170, 255);
                unit.color = new Color32(170, 170, 170, 255);
            }
        }
        if (!Deathflag && UnityLife <= 3)
        {
            Warnig.SetActive(true);
        }
        else
        {
            Warnig.SetActive(false);
        }
        if (UnityLife <= 0)
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
        if (rotecount <= 180)
        {
            if (conveyor.direction == Direction.Right)
            {
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                transform.Rotate(0, 0, -rote);
                //transform.Rotate(0, 0, -1);
            }
            else
            {
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, an), angle);
                transform.Rotate(0, 0, rote);
                //transform.Rotate(0, 0, -1);
            }
        }
        if (LRfrag)
        {
            rb.velocity = new Vector2(conveyor.speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-conveyor.speed, 0);
        }
        if (Rotefrag == true)
            rb.velocity = new Vector2(0, 0);
        if (rotecount >= 180)
        {
            Rotefrag = false;
        }
        rotecount += 1 * conveyor.speed;
        rote = 1 * conveyor.speed;
        if (rotecount > 180)
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
            healobj.SetActive(true);
            Vector3 euler = new Vector3(-45, 0, 0);
            //healobj.transform.rotation = Quaternion.Euler(euler);
        }
        if (collision.tag == "wall")
        {
            angle = 0;
            rotecount = 0;
            Rotefrag = true;
            if (LRfrag == true)
            {
                LRfrag = false;
            }
            else
            {
                LRfrag = true;
            }
        }
        if (collision.gameObject.tag == "EnemyBullet" && !healfrag)
        {
            if (!Deathflag)
                UnitLife_Manager(-1);
        }
        if (collision.gameObject.tag == "Bom" && !healfrag)
        {
            if (!Deathflag)
                UnitLife_Manager(-collision.gameObject.GetComponent<Bom>().damege);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            //falseが上の状態
            healfrag = false;
            healobj.SetActive(false);
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
