using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Bal
{
    nomal,
    kantuu,
    Bom,
    Area
}
public class EnemyBallet : MonoBehaviour
{
    public Bal ballet;
    private GameObject target;
    private Vector3 targetpos;
    public float speed;
    private EnemyShot enemy;
    private Vector3 vec;
    private float rad;
    private Vector2 Position;
    public GameObject Bom;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.GetComponent<EnemyShot>();
        target = enemy.target;
        gameObject.transform.parent = null;
        targetpos = target.transform.position;
        if (transform.position.y > targetpos.y)
        {
            targetpos.y += 0.5f;
        }
        else
        {
            targetpos.y -= 0.5f;
        }
        rad = Mathf.Atan2(
target.transform.position.y - transform.position.y,
target.transform.position.x - transform.position.x);
        vec = (targetpos - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (ballet == Bal.nomal)
        {
            transform.position = Vector3.Lerp(transform.position, targetpos, speed);
            if (transform.position == targetpos)
            {
                Destroy(gameObject);
            }
            // 現在位置をPositionに代入
            Position = transform.position;
            // これで特定の方向へ向かって進んでいく。
            Position.x += speed * Mathf.Cos(rad);
            Position.y += speed * Mathf.Sin(rad);
            // 現在の位置に加算減算を行ったPositionを代入する
            transform.position = Position;

            transform.position += transform.forward * speed;
        }
        if(ballet==Bal.kantuu)
        {
            // 現在位置をPositionに代入
            Position = transform.position;
            // これで特定の方向へ向かって進んでいく。
            Position.x += speed * Mathf.Cos(rad);
            Position.y += speed * Mathf.Sin(rad);
            // 現在の位置に加算減算を行ったPositionを代入する
            transform.position = Position;
        }
        if (ballet == Bal.Bom)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -2f, transform.position.z), speed);
            if (transform.position == new Vector3(transform.position.x, -2f, transform.position.z))
            {
                Instantiate(Bom, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ballet == Bal.nomal)
        {
            if (collision.gameObject.tag == "Unit")
            {
                Destroy(gameObject);
            }
        }
        if (ballet==Bal.Bom)
        {
            if (collision.gameObject.tag == "Unit")
            {
                //Instantiate(Bom, gameObject.transform.position, Quaternion.identity);
                //Destroy(gameObject);
            }
        }


    }
}
