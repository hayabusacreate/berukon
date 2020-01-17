using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectNumber : MonoBehaviour
{
    public GameObject serect;
    public int num;
    private SceneChange sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = gameObject.transform.parent.gameObject.GetComponent<SceneChange>();
        serect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneChange.stagenum+1==num)
        {
            serect.SetActive(true);
        }else
        {
            serect.SetActive(false);
        }
    }
}
