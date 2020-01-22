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
    private bool endflag,changefrag;
    private GameObject Text;
    private StageAnim stageAnim;
    private bool frag;
    private static Dictionary<int, int> stagebach=new Dictionary<int, int>();
    public static bool start;
    public AudioSource over,clear,no;
    private bool clearfrag;
    public GameObject Ex,Ex2;
    public Vector3 tyutorial;
    public GameObject yajirusi,yajirusi2;
    // Start is called before the first frame update
    void Start()
    {

        stagenum = 0;
        changeflag = false;
        endflag = false;
        if(scene==Scene.GamePlay)
        {
            foreach (Transform child in transform)
            {
                Text = child.gameObject;
            }
            Text.SetActive(false);
        }
        if (scene == Scene.StageSlect)
        {
            yajirusi.SetActive(false);
            yajirusi2.SetActive(false);
            clearfrag = true;
            for(int i=0;i<stage.Length-2;i++)
            {
                if(sta!=0)
                {
                    if (stagebach[i+1]==0)
                    {
                        clearfrag = false;
                    }
                    if(i<sta-1)
                    {
                        stage[i].transform.position = new Vector3(-40, 0, 0);
                    }
                    if(i == sta-1)
                    {
                        stage[i].transform.position = new Vector3(0, 0, 0);
                    }
                    if(i > sta - 1)
                    {
                        stage[i].transform.position = new Vector3(20, 0, 0);
                    }
                    stageAnim= stage[i].transform.GetComponent<StageAnim>();
                    stageAnim.Eflag = true;
                    stagenum = sta-1;
                }
                else
                {
                    clearfrag = false;
                    stagenum = sta;
                }
            }
        }
        frag = false;
        changefrag = false;
        if(start==false)
        {
            for (int i = 1; i < 12; i++)
            {
                stagebach.Add(i, 0);
            }
            sta = 0;
            start = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        camtime += Time.deltaTime/3;
        if (scene == Scene.GamePlay&&frag==false)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(0, 0, -10), camtime);
            if(cam.transform.position== new Vector3(0, 0, -10))
            {
                frag = true;
            }
        }
        if(changefrag)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(0, 23, -10), camtime);
            if(cam.transform.position.y>=18)
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
            Change();
    }
    void Change()
    {
        time += Time.deltaTime*10;
        if(scene==Scene.Title)
        {
            if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
        if (scene == Scene.StageSlect)
        {
            if (clearfrag)
            {
                Ex.SetActive(true);
                Ex2.SetActive(true);
            }
            else
            {
                Ex.SetActive(false);
                Ex2.SetActive(false);
            }
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.8f)&& stagenum > 0 && movefrag)
            {
                    time = 0;
                    stagenum--;
            }
            if (stagenum < 4)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, tyutorial, time);
            }
            if(stagenum >= 3)
            {
                yajirusi.SetActive(true);
            }else
            {
                yajirusi.SetActive(false);
            }
            if(stagenum <= 4)
            {
                yajirusi2.SetActive(true);
            }else
            {
                yajirusi2.SetActive(false);
            }
            if ((Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetAxis("Horizontal") > 0.8f)&& movefrag)
            {
                if(stagenum < stage.Length - 3 || (stagenum < stage.Length-1 && clearfrag))
                {
                    time = 0;
                    stagenum++;
                }
                
            }
            if (stagenum > 3)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(0, 0, -10), time);
            }
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown("joystick button 0")) 
            {
                changeflag = true;
            }
            if(!changeflag)
            {
                if (stagenum < stage.Length - 1)
                {
                    stage[stagenum + 1].transform.position = Vector3.Lerp(stage[stagenum + 1].transform.position, new Vector3(20, 0, 0), time);
                }
                if(stagenum>3)
                {
                    stage[stagenum].transform.position = Vector3.Lerp(stage[stagenum].transform.position, new Vector3(0, 0, 0), time);
                    if (stage[stagenum].transform.position == new Vector3(0, 0, 0))
                    {
                        movefrag = true;
                    }
                    else
                    {
                        movefrag = false;
                    }
                }
                else
                {
                    stage[stagenum].transform.position = Vector3.Lerp(stage[stagenum].transform.position, new Vector3(-17.5f, 0, 0), time);
                    if (stage[stagenum].transform.position == new Vector3(-17.5f, 0, 0))
                    {
                        movefrag = true;
                    }
                    else
                    {
                        movefrag = false;
                    }
                }
                if (stagenum - 1 >= 0)
                {
                    stage[stagenum - 1].transform.position = Vector3.Lerp(stage[stagenum - 1].transform.position, new Vector3(-40, 0, 0), time);
                }
                speed = stage[stagenum].transform.position.x;
            }else
            {
                stage[stagenum].transform.gameObject.GetComponent<StageAnim>().Sflag = true;
                //stage[stagenum].transform.position = Vector3.Lerp(stage[stagenum].transform.position, new Vector3(0, -100, 0), time);
            }

        }
        if (scene == Scene.GamePlay)
        {
            if(Input.GetKeyDown("joystick button 7"))
            {
                SceneManager.LoadScene("StageSelect");
            }
            if(endflag)
            {
                if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown("joystick button 1"))
                {
                    camtime = 0;
                    changefrag = true;
                }
                if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown("joystick button 0"))
                {
                    SceneManager.LoadScene("T_Stage" + sta);
                }
                Text.SetActive(true);
            }else
            {
                if (core.CoreLife < 0)
                {
                    over.PlayOneShot(over.clip);
                    gameover.SetActive(true);
                    endflag = true;
                }
                if (wave.endflag == true)
                {
                    if (core.CoreLife == 2)
                    {
                        if (stagebach[sta] < 2)
                            stagebach[sta]=2;
                        nodamege.SetActive(true);
                        no.PlayOneShot(no.clip);
                    }
                    else
                    {
                        if (stagebach[sta] < 1)
                            stagebach[sta] = 1;
                        gameclear.SetActive(true);
                        clear.PlayOneShot(clear.clip);
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
    public void StageNumChange(int num)
    {
        sta = num;
    }
    public int StageBach(int stage)
    {
        return stagebach[stage];
    }
}
