using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 3f;
    public float range = 4;

    float startingY;
    int direc = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * direc);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            direc *= -1;
    }
}
