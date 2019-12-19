using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float x;
    public int EnemyLife = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x, 0);
        if(EnemyLife == 0)
        {
            Destroy(gameObject);
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
            EnemyLife_Manager(-1);
            //Debug.Log("ダメージを食らう");
        }
        if(collision.gameObject.tag == "Core")
        {
            Destroy(gameObject);
        }
    }
}
