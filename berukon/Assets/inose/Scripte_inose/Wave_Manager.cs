using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    private float x,y;
    public float purasu;
    public bool enemyflag;
    void Start()
    {
        x= 0;
        y = 1.5f;
        enemyflag = false;
            foreach(GameObject gb in EnemyList)
        {
            if(gb.GetComponent<EnemyMove>().enemySelect==EnemySelect.Drone_enemy)
            {
                GameObject obj= Instantiate(gb, new Vector2(transform.position.x + x, transform.position.y), Quaternion.identity);
                obj.transform.parent = gameObject.transform;
            }
            else
            if (gb.GetComponent<EnemyMove>().enemySelect == EnemySelect.Nazca_Enemy)
            {
                GameObject obj= Instantiate(gb, new Vector2(transform.position.x + x, transform.position.y-y), Quaternion.identity);
                obj.transform.parent = gameObject.transform;
            }
            x +=purasu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int count = transform.childCount;
        if(count==0)
        {
            enemyflag = true;
        }
    }
}
