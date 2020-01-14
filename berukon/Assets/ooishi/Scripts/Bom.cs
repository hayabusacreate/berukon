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
    private CircleCollider2D col;
    private BoxCollider2D box;
    public Colision colision;
    public float hitArea;
    public int damege;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(colision==Colision.Circle)
        {
            col.radius += 0.01f;
            if (col.radius > hitArea)
            {
                Destroy(gameObject);
            }
        }
        if (colision == Colision.Box)
        {
            gameObject.transform.localScale += new Vector3(0, 0.1f, 0);
        }
    }
}
