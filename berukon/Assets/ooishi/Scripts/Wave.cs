using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<GameObject> waves ;
    private Dictionary<int, GameObject> wave;
    private Dictionary<int,Wave_Manager> manager;
    private int count;
    public bool endflag;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        wave = new Dictionary<int, GameObject>();
        manager = new Dictionary<int, Wave_Manager>();
        foreach(var a in waves)
        {
            wave[count] = a;
            manager[count] = a.GetComponent<Wave_Manager>();
            if (count == 0)
            {
                wave[count].SetActive(true);
            }
            else
            {
                wave[count].SetActive(false);
            }
            count++;

        }
        count = 0;
        endflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
    void Check()
    {
        if (manager[count].enemyflag == true)
        {
            if (count < manager.Count-1)
            {
                wave[count].SetActive(false);
                count++;
                wave[count].SetActive(true);
            }
            else
            {
                endflag = true;
            }
        }
    }
}
