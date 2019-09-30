using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerConroller _playerConroller;

    void FixedUpdate()
    {
        if (_playerConroller.currentTransform)
        {
            transform.position = new Vector3(0f, _playerConroller.currentTransform.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }
    }
}
