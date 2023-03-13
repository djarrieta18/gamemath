using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionNumbers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    public Transform Number_eight;
    public Vector2 initialPosition;
    public Vector2 mousePosition;
    public float deltaX, deltaY;
    public static bool locked;
    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - Number_eight.position.x)<= 0.5f &&
            Mathf.Abs(transform.position.y - Number_eight.position.y)<=0.5f)
        {
            
            transform.position = new Vector2(Number_eight.position.x, Number_eight.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
