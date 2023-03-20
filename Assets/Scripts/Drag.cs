using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag  : MonoBehaviour
{
   

    private bool _dragging;
    private Vector2 _offset,_originalPosition;
    [SerializeField]private bool value;
    [SerializeField] Transform container;
    bool isPlaced;

    public bool Value { get => value; }

    void Awake()
    {
        _originalPosition = transform.position;
        isPlaced = false;
    }

    public void SetValue(bool val)
    {
        value = val;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_dragging) return;
        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

     void OnMouseDown()
    {
        if (isPlaced)
            return;

        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
    }
     void OnMouseUp()
    {

        //transform.position = GetMousePos();
        if((Vector2.Distance(container.position, transform.position)<1f)&&value)
        {
            transform.position = container.position;
            isPlaced = true;
        }
        else
        {
            transform.position = _originalPosition;

        }
        _dragging = false;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
