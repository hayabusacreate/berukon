using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colision
{
    Circle,
    Box,
}
public class Bom : MonoBehaviour
{
    private GameObject col;
    private BoxCollider2D box;
    public Colision colision;
    public float hitArea;
    public int damege;
    public float AreaSpeed;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        if(colision == Colision.Box)
        {
            box = gameObject.transform.GetComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(colision==Colision.Circle)
        {
            gameObject.transform.localScale += new Vector3(AreaSpeed,AreaSpeed,AreaSpeed);
            if (gameObject.transform.localScale.x > hitArea)
            {
                Destroy(gameObject);
            }
        }
        if (colision == Colision.Box)
        {
            box.size += new Vector2(0, AreaSpeed);
            //gameObject.transform.localScale += new Vector3(0, AreaSpeed, 0);
            if(time>hitArea)
            {
                Destroy(gameObject);
            }
        }
    }
}
