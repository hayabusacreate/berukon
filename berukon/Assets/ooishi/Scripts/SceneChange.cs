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
        if(scene==Scene.Title)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Stage1");
            }
        }
        if (scene == Scene.StageSlect)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                stagenum--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                stagenum++;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("test");
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
