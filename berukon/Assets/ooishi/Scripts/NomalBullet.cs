using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : MonoBehaviour
{
    private GameObject target;
    private Vector2 targetpos;
    public float speed;
    private UnitShot unit;
    // Start is called before the first frame update
    void Start()
    {
        unit = gameObject.transform.parent.GetComponent<UnitShot>();
        target= unit.target;
        gameObject.transform.parent = null;
        targetpos = target.transform.position;
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
        transform.position =Vector3.Lerp(transform.position,targetpos,speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
           Destroy(gameObject);
        }
    }
}
