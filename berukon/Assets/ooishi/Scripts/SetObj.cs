using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObj : MonoBehaviour
{
    public GameObject berukon, wall, berukonR, berukonLeft;
    private bool setflag;
    // Start is called before the first frame update
    void Start()
    {
        setflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(setflag)
        {
            Destroy(gameObject);
        }else
        {
            setflag = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Conveyor")
        {
            Instantiate(berukon, transform.position, Quaternion.identity);
            setflag = true;
        }
        if (collision.gameObject.tag == "wall")
        {
            Instantiate(wall, transform.position, Quaternion.identity);
            setflag = true;
        }
        if (collision.gameObject.tag == "ConveyorRight")
        {
            Instantiate(berukonR, transform.position, Quaternion.identity);
            setflag = true;
        }
        if (collision.gameObject.tag == "ConveyorLeft")
        {
            Instantiate(berukonLeft, transform.position, Quaternion.identity);
            setflag = true;
        }
    }
}
