using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    private Dictionary<int, GameObject> wave;
    private int wavecount;
    private bool sponefrag;
    private float y;
    public float wavetime;
    private float time;
    public bool enemyflag;
    void Start()
    {
        wave = new Dictionary<int, GameObject>();
        y = 1.5f;
        enemyflag = false;
        wavecount = 0;
            foreach(GameObject gb in EnemyList)
        {
            wave[wavecount] = gb;
            wavecount++;
        }
        wavecount = 0;
        sponefrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(wavecount<EnemyList.Count&&time>wavetime)
        {
            if (wave[wavecount].GetComponent<EnemyMove>().enemySelect == EnemySelect.Drone_enemy|| wave[wavecount].GetComponent<EnemyMove>().enemySelect == EnemySelect.WarpEnemy)
            {
                GameObject obj = Instantiate(wave[wavecount], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                obj.transform.parent = gameObject.transform;
            }
            else
            if (wave[wavecount].GetComponent<EnemyMove>().enemySelect == EnemySelect.Nazca_Enemy)
            {
                GameObject obj = Instantiate(wave[wavecount], new Vector2(transform.position.x, transform.position.y - y), Quaternion.identity);
                obj.transform.parent = gameObject.transform;
            }
            time = 0.0f;
            wavecount++;
        }
        if(wavecount>= EnemyList.Count)
        {
            sponefrag = true;
        }
        if(sponefrag)
        {
            int count = transform.childCount;
            if (count == 0)
            {
                enemyflag = true;
            }
        }
    }
}
