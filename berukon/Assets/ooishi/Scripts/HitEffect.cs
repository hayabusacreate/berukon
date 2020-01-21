using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject hit, safe;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        hit.SetActive(false);
        safe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<-3)
        {
            safe.SetActive(true);
        }
        else
        {
            hit.SetActive(true);
        }
        time += Time.deltaTime;
        if(time>1)
        {
            Destroy(gameObject);
        }
    }
}
