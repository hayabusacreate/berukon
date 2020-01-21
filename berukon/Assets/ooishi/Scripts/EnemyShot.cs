using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BalletChoce
{
    nomal,
    kantuu,
    Bom,
    Area,
    None
}
public class EnemyShot : MonoBehaviour
{
    public BalletChoce ballet;
    public GameObject shot,kantuu,Bom,Area;
    public GameObject target;
    public float shotTime;
    private float time;
    private bool hitfrag;
    public Dictionary<int, GameObject>units;
    private GameObject unitsave, unitsave2;
    private EnemyMove eneMove;
    private int targetcount;
    private GameObject housin;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        hitfrag = false;
        units = new Dictionary<int, GameObject>();
        eneMove = gameObject.transform.parent.gameObject.GetComponent<EnemyMove>();
        foreach (Transform child in transform)
        {
            //child is your child transfor
            housin = child.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(eneMove.enemySelect==EnemySelect.Nazca_Enemy&&hitfrag)
        {
            Vector3 posDif = housin.transform.position - units[0].transform.position;
            float angle = Mathf.Atan2(posDif.y, posDif.x) * Mathf.Rad2Deg;
            Vector3 euler = new Vector3(0, 0, angle);

            housin.transform.rotation = Quaternion.Euler(euler);
        }
        Sort();
        Shot();
    }
    void Shot()
    {
        time += Time.deltaTime;

        if (time >= shotTime && hitfrag)
        {
            // Do anything
            if(ballet==BalletChoce.nomal)
            {
                time = 0.0f;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(shot, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
            if(ballet==BalletChoce.kantuu)
            {
                time = 0.0f;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(kantuu, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
            if (ballet == BalletChoce.Bom)
            {
                time = 0.0f;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(Bom, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
            if (ballet == BalletChoce.Area)
            {
                time = 0.0f;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(Area, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
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
        if(units.Count>0)
        {
            if (target.GetComponent<UnitMove>().Deathflag == true)
            {
                if (units.Count == 1)
                {
                    units.Remove(units.Count - 1);
                    hitfrag = false;
                }
                else
                {
                    for (int i = 0; i < units.Count - 1; i++)
                    {
                        if (i < units.Count - 1)
                        {
                            units.Remove(i);
                            units.Add(i, units[i + 1]);
                        }
                        else
                        {
                            units.Remove(i);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit"&&collision.gameObject.GetComponent<UnitMove>().Deathflag==false)
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
