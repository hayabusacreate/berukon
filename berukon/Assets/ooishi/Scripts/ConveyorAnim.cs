using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anim
{
    Sentar,
    Right,
    Left
}
public class ConveyorAnim : MonoBehaviour
{
    private Conveyor conveyor;
    private Direction conveyorcheck;
    private bool RLChange;
    public Anim state;
    private Animator anim;
    private float speed;
    private float r, g, b;
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
        conveyor = transform.root.gameObject.GetComponent<Conveyor>();
            if(conveyor.direction==Direction.Right)
        {
            conveyorcheck= conveyor.direction;
            anim.SetBool("LR",true);
        }
        else
        {
            conveyorcheck= conveyor.direction;
            anim.SetBool("LR",false);
        }
        r = GetComponent<Renderer>().material.color.r;
        g = GetComponent<Renderer>().material.color.g;
        b = GetComponent<Renderer>().material.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (conveyorcheck != conveyor.direction)
        {
            speed = -speed;
        }
        if (state==Anim.Sentar)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.0f)
            {
                anim.Play(Animator.StringToHash("Base Layer.berukon 0"), 0, 1.0f);
            }
        }
        if (state == Anim.Right)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.0f)
            {
                anim.Play(Animator.StringToHash("Base Layer.beruR 1"), 0, 1.0f);
            }
        }
        if (state == Anim.Left)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.0f)
            {
                anim.Play(Animator.StringToHash("Base Layer.berukonlefft 1"), 0, 1.0f);
            }
        }
        anim.speed = conveyor.speed;

        ChangeColor();
    }
    private void ChangeColor()
    {
        if (conveyor.moveflag)
        {
            GetComponent<Renderer>().material.color = new Color(256, g, b);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(r, g, b);
        }
    }
}
