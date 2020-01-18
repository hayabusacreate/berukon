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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(colision==Colision.Circle)
        {
            gameObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
            if (gameObject.transform.localScale.x > hitArea)
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
