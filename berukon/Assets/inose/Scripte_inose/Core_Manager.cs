﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Core_Manager : MonoBehaviour
{
    public int CoreLife = 5;
    public SpriteRenderer main, shadow,core;
    public Sprite[] mains,shadows,cores;
    public GameObject obj,smoke;
    private int count;
    public PlayableDirector playableDirector;
    public AudioSource se;
    // Start is called before the first frame update
    void Start()
    {
        main.sprite = mains[0];
        shadow.sprite = shadows[0];
        core.sprite = cores[0];
        count = 0;
        smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CoreLife_Manager(int Life)
    {
        se.PlayOneShot(se.clip);
        CoreLife = CoreLife + Life;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(obj,new Vector3(transform.position.x+3,transform.position.y,transform.position.z),Quaternion.identity);
            CoreLife_Manager(-1);
            if(mains.Length-1>count)
            {
                count++;
                main.sprite = mains[count];
                shadow.sprite = shadows[count];
            }
            if(CoreLife==-1)
            {
                core.sprite = cores[1];
                smoke.SetActive(true);
            }
            playableDirector.Play();
        }
    }
}
