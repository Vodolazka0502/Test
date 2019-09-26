using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
   
    public float speed = 2;

    private Vector3 newPosition;
    public Transform currentTransform;
    void FixedUpdate()
    {
        if (currentTransform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
            }
            currentTransform.position = Vector2.MoveTowards(currentTransform.position, newPosition, Time.deltaTime * speed);
        }
    }
    public void SwitchObject(Transform currentTransform)
    {
        newPosition = currentTransform.position;

        this.currentTransform = currentTransform;
    }
   
}
