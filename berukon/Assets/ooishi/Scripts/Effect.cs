using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public int effect;
    private int check;
    private float time;
    private float risett;
    // Start is called before the first frame update
    void Start()
    {
        check = 0;
        effect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        if(check!=effect)
        {
            check = effect;
            time = 0;
        }
        if(check>1)
        {
            time += Time.deltaTime;
        }
        if(time>0.5f)
        {
            check = 0;
            effect = 0;
        }
    }
}
