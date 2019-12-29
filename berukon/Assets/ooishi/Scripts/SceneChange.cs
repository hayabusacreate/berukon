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
    public Wave_Manager wave;
    // Start is called before the first frame update
    void Start()
    {
        
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
                SceneManager.LoadScene("test");
            }
        }
        if (scene == Scene.StageSlect)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("test");
            }
        }
        if (scene == Scene.GamePlay)
        {
            if (core.CoreLife<0||wave.enemyflag)
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
