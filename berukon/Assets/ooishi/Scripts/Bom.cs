using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    private CircleCollider2D col;
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
        col.radius += 0.01f;
        if(col.radius>hitArea)
        {
            Destroy(gameObject);
        }
    }
}
