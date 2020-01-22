using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject nice,great,exe, safe;
    private float time;
    private Effect effect;
    private bool change;
    // Start is called before the first frame update
    void Start()
    {
        effect = GameObject.Find("Effect").GetComponent<Effect>();
        nice.SetActive(false);
        great.SetActive(false);
        exe.SetActive(false);
        safe.SetActive(false);
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(change==false)
        {
            if (transform.position.x < -3)
            {
                safe.SetActive(true);
            }
            if (effect.effect == 0)
            {
                effect.effect++;
                nice.SetActive(true);
            }
            else if (effect.effect == 1)
            {
                effect.effect++;
                great.SetActive(true);
            }
            else if (effect.effect >= 2)
            {
                effect.effect++;
                exe.SetActive(true);
            }
            change = true;
        }
        time += Time.deltaTime;
        if(time>0.75f)
        {
            Destroy(gameObject);
        }
    }
}
