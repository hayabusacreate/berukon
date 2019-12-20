using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject shot;
    public GameObject target;
    public float shotTime;
    private float time;
    private bool hitfrag;
    public Dictionary<int, GameObject>units;
    private GameObject unitsave, unitsave2;
    private EnemyMove eneMove;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        hitfrag = false;
        units = new Dictionary<int, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
        Sort();
    }
    void Shot()
    {
        time += Time.deltaTime;

        if (time >= shotTime && hitfrag)
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
        if (units.Count >= 2)
        {
            bool isEnd = false;
            int finAdjust = 1; // 最終添え字の調整値
            while (!isEnd)
            {
                bool loopSwap = false;
                for (int i = 0; i < units.Count - finAdjust; i++)
                {
                    float nierdistance = Vector2.Distance(transform.position, units[i].transform.position);
                    float nowdistance = Vector2.Distance(transform.position, units[i + 1].transform.position);
                    if (nierdistance > nowdistance)
                    {
                        unitsave = units[i];
                        unitsave2 = units[i + 1];
                        units[i] = unitsave2;
                        units[i + 1] = unitsave;
                        loopSwap = true;
                    }
                }
                if (!loopSwap) // Swapが一度も実行されなかった場合はソート終了
                {
                    isEnd = true;
                }
                finAdjust++;
            }
            target = units[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            float nierdistance = Vector2.Distance(transform.position, collision.gameObject.transform.position);
            if (units.Count == 0)
            {
                units.Add(0, collision.gameObject);
            }
            else
            {
                units.Add(units.Count, collision.gameObject);
            }
            if (hitfrag == false)
            {
                hitfrag = true;
            }
            target = units[0];
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            if (units.Count == 1)
            {
                hitfrag = false;
            }
            units.Remove(units.Count - 1);

        }
    }
}
