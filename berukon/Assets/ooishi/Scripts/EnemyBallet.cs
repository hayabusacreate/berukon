using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBallet : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetpos;
    public float speed;
    private EnemyShot enemy;
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
        }else
        {
            targetpos.y -= 0.5f;
        }
    }

        // Update is called once per frame
        void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, speed);
            if (transform.position == targetpos)
            {
                Destroy(gameObject);
            }
        

            transform.position += transform.forward * speed;
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(unit.target.transform.position - transform.position), 0.3f);
        //targetに向かって進む
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "Unit")
            {
                Destroy(gameObject);
            }
        
    }
}
