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
    private Dictionary<int,GameObject> enemys;
    private GameObject enemysave,enesave2;
    private bool healfrag;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        hitfrag = false;
        enemys = new Dictionary<int, GameObject>();
;    }

    // Update is called once per frame
    void Update()
    {
        Shot();
        Sort();
    }
    void Shot()
    {
        time += Time.deltaTime;

        if (time >= shotTime&&hitfrag&&!healfrag)
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
        if(enemys.Count>=2)
        {
            bool isEnd = false;
            int finAdjust = 1; // 最終添え字の調整値
            while (!isEnd)
            {
                bool loopSwap = false;
                for (int i = 0; i < enemys.Count - finAdjust; i++)
                {
                    float nierdistance = Vector2.Distance(transform.position, enemys[i].transform.position);
                    float nowdistance = Vector2.Distance(transform.position, enemys[i + 1].transform.position);
                    if (nierdistance > nowdistance)
                    {
                        enemysave = enemys[i];
                        enesave2 = enemys[i + 1];
                        enemys[i] = enesave2;
                        enemys[i + 1] = enemysave;
                        loopSwap = true;
                    }
                }
                if (!loopSwap) // Swapが一度も実行されなかった場合はソート終了
                {
                    isEnd = true;
                }
                finAdjust++;
            }
            target = enemys[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            healfrag = true;
        }
        if (collision.gameObject.tag=="Enemy"&&healfrag==false)
        {
            float nierdistance = Vector2.Distance(transform.position, collision.gameObject.transform.position);
            if (enemys.Count==0)
            {
                enemys.Add(0,collision.gameObject);
            }else
            {
                enemys.Add(enemys.Count, collision.gameObject);
            }
            if (hitfrag==false)
            {
                hitfrag = true;
            }
            target = enemys[0];
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            healfrag = false;
        }
        if (collision.gameObject.tag=="Enemy")
        {
            if(enemys.Count==1)
            {
                hitfrag = false;
            }
                enemys.Remove(enemys.Count-1);
            
        }
    }
}
