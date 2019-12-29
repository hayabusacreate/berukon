using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Manager : MonoBehaviour
{
    public int CoreLife = 5;
    public SpriteRenderer main, shadow;
    public Sprite[] mains,shadows;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        main.sprite = mains[0];
        shadow.sprite = shadows[0];
        count = 0;
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
            if(mains.Length-1>count)
            {
                count++;
                main.sprite = mains[count];
                shadow.sprite = shadows[count];
            }
        }
    }
}
