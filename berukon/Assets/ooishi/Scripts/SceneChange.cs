using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Title,
    StageSlect,
    GamePlay,
    GameOver
}
public class SceneChange : MonoBehaviour
{
    public Scene scene;
    public Core_Manager core;
    public Wave wave;
    public int stagenum;
    public static int sta;
    public GameObject[] stage;
    public float speed;
    public bool movefrag;
    private float time;
    private bool changeflag;
    public GameObject cam;
    private float camtime;
    public GameObject gameover, gameclear, nodamege;
    private bool endflag;
    // Start is called before the first frame update
    void Start()
    {
        stagenum = 0;
        changeflag = false;
        stagenum = sta;
        endflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        sta = stagenum;
        camtime += Time.deltaTime/3;
        if (scene == Scene.GamePlay)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(0, 0, -10), camtime);
        }
            Change();
    }
    void Change()
    {
        time += Time.deltaTime;
        if(scene==Scene.Title)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
        if (scene == Scene.StageSlect)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow)&&stagenum>0&&movefrag)
            {
                time = 0;
                stagenum--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)&&stagenum<stage.Length-1&&movefrag)
            {
                time = 0;
                stagenum++;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                changeflag = true;
            }
            if(!changeflag)
            {
                if (stagenum < stage.Length - 1)
                    stage[stagenum + 1].transform.position = Vector3.Lerp(stage[stagenum + 1].transform.position, new Vector3(20, 0, 0), time);

                stage[stagenum].transform.position = Vector3.Lerp(stage[stagenum].transform.position, new Vector3(0, 0, 0), time);
                if (stagenum - 1 >= 0)
                    stage[stagenum - 1].transform.position = Vector3.Lerp(stage[stagenum - 1].transform.position, new Vector3(-20, 0, 0), time);
                speed = stage[stagenum].transform.position.x;
                if (stage[stagenum].transform.position == new Vector3(0, 0, 0))
                {
                    movefrag = true;
                }
                else
                {
                    movefrag = false;
                }
            }else
            {
                stage[stagenum].transform.gameObject.GetComponent<StageAnim>().flag = true;
                //stage[stagenum].transform.position = Vector3.Lerp(stage[stagenum].transform.position, new Vector3(0, -100, 0), time);
            }

        }
        if (scene == Scene.GamePlay)
        {
            if(endflag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }
            }else
            {
                if (core.CoreLife < 0)
                {
                    gameover.SetActive(true);
                    endflag = true;
                }
                if (wave.endflag == true)
                {
                    if (core.CoreLife == 2)
                    {
                        nodamege.SetActive(true);
                    }
                    else
                    {
                        gameclear.SetActive(true);
                    }
                    endflag = true;
                }
            }
        }
        if (scene == Scene.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
