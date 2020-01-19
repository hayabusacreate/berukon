using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectNumber : MonoBehaviour
{
    private GameObject serect;
    public GameObject clear, nodamege;
    public int num;
    private SceneChange sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = gameObject.transform.parent.gameObject.GetComponent<SceneChange>();
        foreach(Transform child in transform)
        {
            serect = child.gameObject;
        }
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
        if(sceneChange.StageBach(num)>=1)
        {
            clear.SetActive(true);
            if(sceneChange.StageBach(num) >= 2)
            {
                nodamege.SetActive(true);
            }
        }
    }
}
