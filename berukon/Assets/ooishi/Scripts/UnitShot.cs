﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitSelect
{
    NomalShot,
    ThreeShot,
    kanntuuShot,
}
public class UnitShot : MonoBehaviour
{
    public UnitSelect unitSelect;
    public GameObject shot,kanntuu;
    public GameObject target;
    public float shotTime;
    private float count;
    private float time,vrast;
    private bool hitfrag;
    private Dictionary<int,GameObject> enemys;
    private GameObject enemysave,enesave2;
    private UnitMove unitMove;
    private bool healfrag;
    public float threeshottime;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time = 0;
        hitfrag = false;
        enemys = new Dictionary<int, GameObject>();
        unitMove = gameObject.transform.parent.GetComponent<UnitMove>();
    }

    // Update is called once per frame
    void Update()
    {
        healfrag = unitMove.healfrag;
        if(!healfrag)
        {
            Sort();
            Shot();
        }else
        {
            Start();
        }
    }
    void Shot()
    {
        time += Time.deltaTime;

        if (time >= shotTime&&hitfrag&&!healfrag)
        {
            // Do anything
            if(unitSelect==UnitSelect.NomalShot)
            {
                time = 0.0f;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(shot, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
            if(unitSelect==UnitSelect.ThreeShot)
            {
                count++;
                if (count>3)
                {
                    time = 0.0f;
                    count = 0;
                    vrast = 0.0f;
                }else
                {
                    vrast += Time.deltaTime;
                }
                if(vrast>threeshottime)
                {
                    vrast = 0.0f;
                    // プレハブからインスタンスを生成
                    GameObject obj = Instantiate(shot, transform.position, Quaternion.identity);
                    obj.transform.parent = transform;
                }
            }
            if(unitSelect==UnitSelect.kanntuuShot)
            {
                time = 0.0f;
                GameObject obj = Instantiate(kanntuu, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
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
        if (collision.gameObject.tag=="Enemy")
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
        if (collision.gameObject.tag=="Enemy")
        {
            if(enemys.Count==1)
            {
                hitfrag = false;
            }
            Sort();
                enemys.Remove(enemys.Count-1);
            
        }
    }
}
