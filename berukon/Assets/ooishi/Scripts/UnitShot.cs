using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShot : MonoBehaviour
{
    public GameObject shot;
    public GameObject target;
    public float shotTime;
    private float time;
    private bool hitfrag;
    private GameObject[] enemys;
    private GameObject enemysave;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        hitfrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
    void Shot()
    {
        time += Time.deltaTime;

        if (time >= shotTime&&hitfrag)
        {
            // Do anything

            time = 0.0f;
            // プレハブからインスタンスを生成
            GameObject obj = Instantiate(shot, transform.position, Quaternion.identity);
            obj.transform.parent = transform;
        }
    }

    void Sort()
    {
        if(enemys.Length!=0)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                float distance = Vector2.Distance(transform.position, enemys[i].transform.position);
                float distance = Vector2.Distance(transform.position, target.transform.position);
                if (enemys[i].gameObject.transform.position)
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            if(hitfrag==false)
            {
                hitfrag = true;
            }
            target = collision.gameObject;
        }
    }
}
