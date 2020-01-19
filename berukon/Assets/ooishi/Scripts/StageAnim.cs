using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StageAnim : MonoBehaviour
{
    public Animator anim, anim2;
    public GameObject gam;
    public SceneChange sceneChange;
    public bool Sflag,Eflag;
    private float time;
    public PlayableDirector start,end;
    // Start is called before the first frame update
    void Start()
    {
        Sflag = false;
        //Eflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    flag = true;

        //}
        if(Sflag)
        {
            //Anim();
            start.Play();
            time += Time.deltaTime;

        }
        if (time > 0.32f)
        {
            gam.transform.position = Vector3.Lerp(gam.transform.position, new Vector3(0, -100, 0), time);
            if (gam.transform.position.y <= -8)
            {
                sceneChange.stagenum++;
                sceneChange.StageNumChange(sceneChange.stagenum);
                SceneManager.LoadScene("Stage" + sceneChange.stagenum);
                Sflag = false;
            }
        }
        if (Eflag)
        {
            end.Play();
            //time += Time.deltaTime;
            gam.transform.position = Vector3.Lerp(gam.transform.position, new Vector3(0, 0, 0), time);
            if (gam.transform.position.y <= 0)
            {
                Eflag = false;
            }
            if (time > 0.32f)
            {
            }
        }

    }
}
