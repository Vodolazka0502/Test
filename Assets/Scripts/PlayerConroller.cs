using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerConroller : MonoBehaviour
{

    public float speed = 2;

    private Vector3 newPosition;
    public Transform currentTransform;

    public UnityEvent SwitchEvent;

    void FixedUpdate()
    {

        if (currentTransform && (GameController.instance.gameState == GameController.GameState.Play))
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
        if (currentTransform == this.currentTransform) return;

        SwitchEvent.Invoke();

        newPosition = currentTransform.position;
        this.currentTransform = currentTransform;
    }

    public void Reset()
    {
        newPosition = currentTransform.position;
        currentTransform = null;
    }
}
