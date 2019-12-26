using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float x;
    public int EnemyLife = 3;
    private Vector3 deathPos;
    private float speed;
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float cahngeBlue = 1.0f;
    float cahngeAlpha = 0f;
    private Color color;
    private bool deathFrag;
    private NomalBullet nomalBullet;
    void Start()
    {
        deathFrag = false;
        deathPos = new Vector3(20, 0, 0);
        speed = 0.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyLife <= 0)
        {
            //this.gameObject.SpriteRender Color color = new Color(changeRed, changeGreen, cahngeBlue, 0);
            deathFrag = true;
        }
        if(deathFrag)
        {
            transform.position = Vector3.Lerp(transform.position, deathPos, speed);
            if (transform.position.z <19)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            rb.velocity = new Vector2(x, 0);
        }
    }
    public void EnemyLife_Manager(int Life)
    {
        EnemyLife = EnemyLife + Life;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackArea")
        {
            nomalBullet = collision.gameObject.GetComponent<NomalBullet>();
            EnemyLife_Manager(-nomalBullet.damege);
            //Debug.Log("ダメージを食らう");
        }
        if(collision.gameObject.tag == "Core")
        {
            Debug.Log("コアに侵入");
            Destroy(gameObject);
            //もし、ユニットの範囲内でコアに当たってデストロイしてディクショナリーエラーが発生した場合にフラグをtrueすることでエラーをなくせる。
           // deathFrag = true;
        }
       
    }
}
