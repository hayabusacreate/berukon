using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    private float x;
    public float purasu,y;
    void Start()
    {
        x= 0;
            foreach(GameObject gb in EnemyList)
        {
            if(gb.GetComponent<EnemyMove>().enemySelect==EnemySelect.Drone_enemy)
            {
                Instantiate(gb, new Vector2(transform.position.x + x, transform.position.y), Quaternion.identity);
            }else
            if (gb.GetComponent<EnemyMove>().enemySelect == EnemySelect.Nazca_Enemy)
            {
                Instantiate(gb, new Vector2(transform.position.x + x, transform.position.y-y), Quaternion.identity);
            }
            x +=purasu;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
