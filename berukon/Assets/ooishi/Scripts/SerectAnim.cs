using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectAnim : MonoBehaviour
{
    private SceneChange sceneChange;
    private int stage;
    private Animator anim;
    private float speed;
    private bool changeflag;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sceneChange = transform.parent.gameObject.GetComponent<SceneChange>();
        stage = sceneChange.stagenum;
        speed = 0;
        anim.speed = speed;
        anim.SetBool("LR", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(stage>sceneChange.stagenum)
        {
            if(!changeflag)
            {
                changeflag = true;
                speed = 2;
            }
            else
            {
                speed -= 0.01f;
                anim.speed = speed;
                anim.SetBool("LR", true);
                if (speed < 0)
                {
                    changeflag = false;
                    stage = sceneChange.stagenum;
                }
            }
        }
        if (stage < sceneChange.stagenum)
        {
            if (!changeflag)
            {
                changeflag = true;
                speed = 2;
            }
            else
            {
                speed -= 0.01f;
                anim.speed = speed;
                anim.SetBool("LR", false);
                if (speed < 0)
                {
                    changeflag = false;
                    stage = sceneChange.stagenum;
                }
            }
        }
    }
}
