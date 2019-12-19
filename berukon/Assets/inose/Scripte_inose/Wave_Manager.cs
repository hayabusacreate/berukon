using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    private float x;
    public float purasu;
    void Start()
    {
        x= 0;
            foreach(GameObject gb in EnemyList)
        {
            Instantiate(gb, new Vector2(transform.position.x + x, transform.position.y), Quaternion.identity);
            x+=purasu;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
