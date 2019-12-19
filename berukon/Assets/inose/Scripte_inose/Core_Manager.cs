using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Manager : MonoBehaviour
{
    public int CoreLife = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CoreLife_Manager(int Life)
    {
        CoreLife = CoreLife + Life;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            CoreLife_Manager(-1);
        }
    }
}
