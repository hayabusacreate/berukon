using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UnitSelect
{
    NomalShot,
    ThreeShot,
    kanntuuShot,
    BomShot,
    AreaShot,
}
public class UnitShot : MonoBehaviour
{
    public UnitSelect unitSelect;
    public GameObject shot,kanntuu,Bom;
    public GameObject target;
    public float shotTime;
    private float count;
    private float time=0,vrast;
    private bool hitfrag;
    private Dictionary<int,GameObject> enemys;
    private GameObject enemysave,enesave2;
    private UnitMove unitMove;
    private bool healfrag,deathflag;
    public float threeshottime;
    public GameObject housin;
    public Slider _slider;
    public AudioSource se;
    // Start is called before the first frame update
    void Start()
    {
        _slider.maxValue = shotTime;
        count = 0;
        //time = 0;
        hitfrag = false;
        enemys = new Dictionary<int, GameObject>();
        unitMove = gameObject.transform.parent.GetComponent<UnitMove>();
        deathflag = false;
        foreach (Transform child in transform)
        {
            //child is your child transfor
            housin = child.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        deathflag = unitMove.Deathflag;
        healfrag = unitMove.healfrag;
        if(!deathflag)
        {
            _slider.value = time;
            time += Time.deltaTime;
        }
        if (!healfrag&&!deathflag)
        {
            Sort();
            Shot();
            //float angle = GetAngle(housin.transform.position, enemys[0].transform.position);
            if(enemys.Count>0)
            {
                if(unitMove.vrtical==Vrtical.Up)
                {
                    Vector3 posDif = housin.transform.position - enemys[0].transform.position;
                    float angle = Mathf.Atan2(posDif.y, posDif.x) * Mathf.Rad2Deg;
                    Vector3 euler = new Vector3(0, 0, angle+90);

                    housin.transform.rotation = Quaternion.Euler(euler);
                }else
                {
                    Vector3 posDif = housin.transform.position - enemys[0].transform.position;
                    float angle = Mathf.Atan2(posDif.y, posDif.x) * Mathf.Rad2Deg;
                    Vector3 euler = new Vector3(0, 0, angle+90);

                    housin.transform.rotation = Quaternion.Euler(euler);
                }
            }

        }
        else if (hitfrag == false)
        {
            Start();
        }
    }
    void Shot()
    {

        if (time >= shotTime&&hitfrag&&!healfrag)
        {
            // Do anything
            if(unitSelect==UnitSelect.NomalShot)
            {
                se.PlayOneShot(se.clip);
                time = 0.0f;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(shot, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
            if(unitSelect==UnitSelect.ThreeShot)
            {
                if (count>2)
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
                    se.PlayOneShot(se.clip);
                    vrast = 0.0f;
                    // プレハブからインスタンスを生成
                    GameObject obj = Instantiate(shot, transform.position, Quaternion.identity);
                    obj.transform.parent = transform;
                    count++;
                }
            }
            if(unitSelect==UnitSelect.kanntuuShot)
            {
                se.PlayOneShot(se.clip);
                time = 0.0f;
                GameObject obj = Instantiate(kanntuu, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
            }
            if (unitSelect == UnitSelect.BomShot)
            {
                se.PlayOneShot(se.clip);
                time = 0.0f;
                GameObject obj = Instantiate(Bom, transform.position, Quaternion.identity);
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
