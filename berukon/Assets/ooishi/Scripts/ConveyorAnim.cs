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
    private int speed;
    public Anim state;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
        conveyor = transform.root.gameObject.GetComponent<Conveyor>();
            if(conveyor.direction==Direction.Right)
        {
            conveyorcheck= conveyor.direction;
            speed = 1;
            anim.SetBool("LR",true);
        }
        else
        {
            conveyorcheck= conveyor.direction;
            speed = -1;
            anim.SetBool("LR",false);
        }
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



    }
}
