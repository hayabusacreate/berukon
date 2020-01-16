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
    public bool flag;
    private float time;
    private PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = gameObject.transform.GetComponent<PlayableDirector>();
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    flag = true;

        //}
        if(flag)
        {
            //Anim();
            playableDirector.Play();
            time += Time.deltaTime;
        }
        if(time>0.32f)
        {
            gam.transform.position = Vector3.Lerp(gam.transform.position, new Vector3(0, -100, 0), time);
            if (gam.transform.position.y <= -8)
            {
                sceneChange.stagenum++;
                SceneManager.LoadScene("Stage" + sceneChange.stagenum);
                flag = false;
            }
        }

    }
    public void Anim()
    {
        anim.SetTrigger("arm");
        anim2.SetTrigger("arm");
        gam.transform.position = Vector3.Lerp(gam.transform.position, new Vector3(0, -7, 0), time);
    }
}
