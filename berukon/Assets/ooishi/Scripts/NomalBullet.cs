using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Ballet
{
    Nomal,
    kantuu,
}
public class NomalBullet : MonoBehaviour
{
    public Ballet ballet;
    private GameObject target;
    private Vector3 targetpos;
    public float speed;
    private UnitShot unit;
    private float rad;
    public int damege;
    private Vector2 Position;

    // Start is called before the first frame update
    void Start()
    {
        unit = gameObject.transform.parent.GetComponent<UnitShot>();
        target= unit.target;
        gameObject.transform.parent = null;
        targetpos = target.transform.position;
        //if (ballet == Ballet.kantuu)
        //{
        //    transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            
        //    //targetに向かって進む
        //}
        rad = Mathf.Atan2(
    target.transform.position.y - transform.position.y,
    target.transform.position.x - transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(unit.target.transform.position - transform.position), 0.3f);
        //targetに向かって進む
        if(ballet==Ballet.Nomal)
        {
            transform.position = Vector3.Lerp(transform.position, targetpos, speed);
            if (transform.position == targetpos)
            {
                Destroy(gameObject);
            }
        }
        if(ballet==Ballet.kantuu)
        {
            //transform.position += transform.forward * speed;
            // 現在位置をPositionに代入
            Position = transform.position;
            // x += SPEED * cos(ラジアン)
            // y += SPEED * sin(ラジアン)
            // これで特定の方向へ向かって進んでいく。
            Position.x += speed* Mathf.Cos(rad);
            Position.y += speed* Mathf.Sin(rad);
            // 現在の位置に加算減算を行ったPositionを代入する
            transform.position = Position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ballet==Ballet.Nomal)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}
