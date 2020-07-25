using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Tutrial : MonoBehaviour
{
    private PlayableDirector playableDirector;
    private int count;
    private float time;
    public Conveyor conveyor,conveyor2;
    private bool flag;
    public bool endflag;
    public GameObject[] icons;
    public Renderer[] icon;
    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        count = 0;
        flag = false;
        endflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        switch(count)
        {
            case 0:
                playableDirector.Play();
                if (time > 0.99f)
                {
                    count++;
                }
                break;
            case 1:
            case 2:
            case 5:
            case 6:
            case 7:
                icons[0].SetActive(true);
                if (time>0.99f)
                {
                    playableDirector.Pause();
                }
                if(Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    if(touch.phase==TouchPhase.Began)
                    {
                        playableDirector.Play();
                        time = 0;
                        count++;
                        icons[0].SetActive(false);
                    }
                }
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
                {
                    playableDirector.Play();
                    time = 0;
                    count++;
                    icons[0].SetActive(false);
                }
                break;
            case 3:
                icons[1].SetActive(true);
                icons[2].SetActive(true);
                if (time > 0.99f)
                {
                    playableDirector.Pause();
                }
                if (conveyor.speed >= 3 && flag == false)
                {
                    icons[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    flag = true;
                }
                if (flag == true && conveyor.speed <= 0.5f)
                {
                    icons[2].GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                    icons[1].SetActive(false);
                    icons[2].SetActive(false);
                    playableDirector.Play();
                    time = 0;
                    flag = false;
                    count++;
                }
                break;
            case 4:
                icons[3].SetActive(true);
                icons[4].SetActive(true);
                icons[5].SetActive(true);
                if (time > 0.99f)
                {
                    playableDirector.Pause();
                }
                if (conveyor2.speed >= 1 && flag == false)
                {
                    icons[3].SetActive(false);
                    icons[4].SetActive(false);
                    playableDirector.Play();
                    time = 0;
                    flag = false;
                    count++;
                }
                if(Input.GetKeyDown("joystick button 1"))
                {
                    icons[3].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                }
                break;
            case 8:
                if(Input.touchCount>0)
                {
                    touch = Input.GetTouch(0);
                    if(touch.phase==TouchPhase.Began)
                    {
                        endflag = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
                {
                    endflag = true;
                }
                break;

        }
    }
}
