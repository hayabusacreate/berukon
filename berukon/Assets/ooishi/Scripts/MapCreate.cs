using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject SetObj;
    public GameObject[] tilemap;
    private bool dethflag;
    // Start is called before the first frame update
    void Start()
    {
        for(int x=-9;x<9;x++)
        {
            for(int y=-4;y<6;y++)
            {
                Instantiate(SetObj, new Vector2(x+0.5f, y-0.5f), Quaternion.identity);
            }
        }
        dethflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dethflag)
        {
            foreach(var a in tilemap)
            {
                Destroy(a);
            }
        }else
        {
            dethflag = true;
        }
    }
}
