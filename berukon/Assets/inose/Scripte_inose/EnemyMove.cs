using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemySelect
{
    Drone_enemy,
    Nazca_Enemy,
    Null_Enemy
}
public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemySelect enemySelect;
    Rigidbody2D rb;
    public float x,y;
    public int EnemyLife = 3;
    private Vector3 deathPos;
    private float deathspeed;
    public float speed;
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float cahngeBlue = 1.0f;
    float cahngeAlpha = 0f;
    private Color color;
    private bool deathFrag;
    private NomalBullet nomalBullet;
    public Slider slider;
    private Conveyor conveyor;
    public bool conflag;
    private Wave_Manager wave;
    void Start()
    {
        deathFrag = false;
        deathPos = new Vector3(20, 0, 0);
        deathspeed = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        slider.maxValue = EnemyLife;
        conflag = false;
        x = -speed;
        if(enemySelect==EnemySelect.Null_Enemy)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = EnemyLife;
        if (enemySelect == EnemySelect.Drone_enemy)
        {
            if (EnemyLife <= 0)
            {
                //this.gameObject.SpriteRender Color color = new Color(changeRed, changeGreen, cahngeBlue, 0);
                deathFrag = true;
            }
            if (deathFrag)
            {
                transform.position = Vector3.Lerp(transform.position, deathPos, deathspeed);
                if (transform.position.z < 19)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(x, 0);
        }
        if (enemySelect == EnemySelect.Nazca_Enemy)
        {
            if (EnemyLife <= 0)
            {
                //this.gameObject.SpriteRender Color color = new Color(changeRed, changeGreen, cahngeBlue, 0);
                deathFrag = true;
            }
            if (deathFrag)
            {
                transform.position = Vector3.Lerp(transform.position, deathPos, deathspeed);
                if (transform.position.z < 19)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(x, 0);
        }
        if(conflag)
        {
            if(conveyor.direction==Direction.Right)
            {
                x =-speed+ conveyor.speed/2;
            }
            if (conveyor.direction == Direction.Left)
            {
                x =-speed- conveyor.speed/2;
            }
        }else
        {
            x = -speed;
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
                //Debug.Log("ダメージを食らう");
            }
            if (collision.gameObject.tag == "Core")
            {
                //Debug.Log("コアに侵入");
                deathFrag = true;
                //もし、ユニットの範囲内でコアに当たってデストロイしてディクショナリーエラーが発生した場合にフラグをtrueすることでエラーをなくせる。
                // deathFrag = true;
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
                Debug.Log("コアに侵入");
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
