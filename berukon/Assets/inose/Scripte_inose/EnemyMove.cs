using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemySelect
{
    Drone_enemy,
    Nazca_Enemy,
    WarpEnemy,
    Null_Enemy
}
public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemySelect enemySelect;
    Rigidbody2D rb;
    private float x;
    public int EnemyLife = 3;
    private Vector3 deathPos;
    private float deathspeed;
    public float speed;
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float cahngeBlue = 1.0f;
    float cahngeAlpha = 0f;
    private Color color;
    public bool deathFrag;
    private NomalBullet nomalBullet;
    private Bom bom;
    public Slider slider;
    private Conveyor conveyor;
    public bool conflag;
    private Wave_Manager wave;
    public GameObject DeathEffect;
    public AudioSource death;
    private SpriteRenderer sprite;
    private float time;
    public float StopTime;
    public GameObject hari;
    private Vector3 a,b;
    public AudioSource warpse;
    private bool warp;
    void Start()
    {
        warp = false;
        sprite = gameObject.transform.GetComponent<SpriteRenderer>();
        deathFrag = false;
        deathPos = new Vector3(40, 0, 0);
        deathspeed = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        slider.maxValue = EnemyLife;
        conflag = false;
        x = -speed;
        if(enemySelect==EnemySelect.Null_Enemy)
        {
            Destroy(gameObject);
        }
        a = new Vector3(0, 0, time).normalized;
        b = new Vector3(0, 0, StopTime).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        slider.value = EnemyLife;
        if (enemySelect == EnemySelect.Drone_enemy|| enemySelect == EnemySelect.Nazca_Enemy)
        {
            rb.velocity = new Vector2(x, 0);
            if (EnemyLife <= 0&&!deathFrag)
            {
                //this.gameObject.SpriteRender Color color = new Color(changeRed, changeGreen, cahngeBlue, 0);
                deathFrag = true;
                death.PlayOneShot(death.clip);
                sprite.enabled=false;
                Instantiate(DeathEffect, gameObject.transform.position, Quaternion.identity);
            }
            if (deathFrag)
            {
                transform.position = Vector3.Lerp(transform.position,new Vector3(deathPos.x, transform.position.y, transform.position.z), deathspeed);
                if (transform.position.x > 9)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(x, 0);
        }
        if(enemySelect==EnemySelect.WarpEnemy)
        {
            if(time>StopTime)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-8, transform.position.y, transform.position.z), speed);
            }else
            {
                if(!warp)
                {
                    warpse.PlayOneShot(warpse.clip);
                    warp = true;
                }
                hari.transform.eulerAngles =new Vector3(0,0,(1-(time/StopTime))*360) ;
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), deathspeed);
            }
            if (EnemyLife <= 0 && !deathFrag)
            {
                //this.gameObject.SpriteRender Color color = new Color(changeRed, changeGreen, cahngeBlue, 0);
                deathFrag = true;
                death.PlayOneShot(death.clip);
                sprite.enabled = false;
                Instantiate(DeathEffect, gameObject.transform.position, Quaternion.identity);
            }
            if (deathFrag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(deathPos.x, transform.position.y, transform.position.z), deathspeed);
                if (transform.position.x > 9)
                {
                    Destroy(gameObject);
                }
            }
        }
        if(!deathFrag)
        {
            if (conflag)
            {
                if (conveyor.direction == Direction.Right)
                {
                    x = -speed + conveyor.speed / 2;
                }
                if (conveyor.direction == Direction.Left)
                {
                    x = -speed - conveyor.speed / 2;
                }
            }
            else
            {
                x = -speed;
            }
        }
    }
    public void EnemyLife_Manager(int Life)
    {
        EnemyLife = EnemyLife + Life;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemySelect == EnemySelect.Drone_enemy)
        {
            if (collision.gameObject.tag == "AttackArea")
            {
                nomalBullet = collision.gameObject.GetComponent<NomalBullet>();
                EnemyLife_Manager(-nomalBullet.damege);
            }
            if (collision.gameObject.tag == "Core")
            {
                deathFrag = true;
                //もし、ユニットの範囲内でコアに当たってデストロイしてディクショナリーエラーが発生した場合にフラグをtrueすることでエラーをなくせる。
            }
            if(collision.gameObject.tag == "Bom")
            {
                bom = collision.gameObject.GetComponent<Bom>();
                EnemyLife_Manager(-bom.damege);
            }
        }
        if (enemySelect == EnemySelect.Nazca_Enemy)
        {
            if (collision.gameObject.tag == "AttackArea")
            {
                nomalBullet = collision.gameObject.GetComponent<NomalBullet>();
                EnemyLife_Manager(-nomalBullet.damege);
                //Debug.Log("ダメージを食らう");

            }
            if (collision.gameObject.tag == "Core")
            {
                deathFrag = true;
                //もし、ユニットの範囲内でコアに当たってデストロイしてディクショナリーエラーが発生した場合にフラグをtrueすることでエラーをなくせる。
                // deathFrag = true;
            }
        }
        if (enemySelect == EnemySelect.WarpEnemy)
        {
            if (collision.gameObject.tag == "AttackArea")
            {
                nomalBullet = collision.gameObject.GetComponent<NomalBullet>();
                EnemyLife_Manager(-nomalBullet.damege);
                //Debug.Log("ダメージを食らう");

            }
            if (collision.gameObject.tag == "Core")
            {
                deathFrag = true;
                //もし、ユニットの範囲内でコアに当たってデストロイしてディクショナリーエラーが発生した場合にフラグをtrueすることでエラーをなくせる。
                // deathFrag = true;
            }
        }
        if (collision.gameObject.tag == "wall")
        {
            if (conflag)
            {
                conflag = false;
            }
            else
            {
                conflag = true;
            }
            conveyor = collision.transform.root.gameObject.GetComponent<Conveyor>();
        }
       // Debug.Log(collision.gameObject.tag);
    }
    private void OnCollisionExit2D(Collision2D collision)
    { 
    }
}
