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
    public GameObject[] stage;
    public float speed;
    public bool movefrag;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        stagenum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Change();
    }
    void Change()
    {
        time += Time.deltaTime/60;
        if(scene==Scene.Title)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Stage1");
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
                SceneManager.LoadScene("test");
            }
            if (stagenum<stage.Length-1)
            stage[stagenum+1].transform.position = Vector3.Lerp(stage[stagenum + 1].transform.position, new Vector3(20, 0, 0),time);

            stage[stagenum].transform.position = Vector3.Lerp(stage[stagenum].transform.position, new Vector3(0, 0, 0), time);
            if(stagenum-1>=0)
            stage[stagenum-1].transform.position = Vector3.Lerp(stage[stagenum - 1].transform.position, new Vector3(-20, 0, 0), time);
            speed = stage[stagenum].transform.position.x;
            if(stage[stagenum].transform.position==new Vector3(0,0,0))
            {
                movefrag = true;
            }else
            {
                movefrag=false;
            }
        }
        if (scene == Scene.GamePlay)
        {
            if (core.CoreLife<0||wave.endflag==true)
            {
                SceneManager.LoadScene("Title");
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
