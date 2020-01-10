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
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sceneChange = transform.parent.gameObject.GetComponent<SceneChange>();
        stage = sceneChange.stagenum;
        speed = 0;
        anim.speed = speed;
        anim.SetBool("LR", true);
        changeflag = false;
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
                count++;

                anim.speed = -sceneChange.speed;
                anim.SetBool("LR", false);
                if (sceneChange.movefrag)
                {
                    changeflag = false;
                    stage = sceneChange.stagenum;
                    speed = 0;
                    count = 0;
                    anim.speed = speed;
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
                count++;
                anim.speed = sceneChange.speed;
                anim.SetBool("LR", true);
                if (sceneChange.movefrag)
                {
                    speed = 0;
                    anim.speed = speed;
                    count = 0;
                    changeflag = false;
                    stage = sceneChange.stagenum;
                }
            }
        }
    }
}
