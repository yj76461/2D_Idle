using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMoveCamera : MonoBehaviour
{
    Vector2 clickPoint;
    float dragSpeed = 20.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) clickPoint = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            
            Vector3 position
                = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

            //position.z = position.y;
            //position.y = .0f;

            Vector3 move = new Vector3(position.x, -position.y, position.z) * (Time.deltaTime * dragSpeed);
            
            float x = transform.position.x;
            float z = transform.position.z;
            //float y = transform.position.y;

            transform.Translate(move);
            transform.transform.position = new Vector3(x, transform.position.y, z);
        
        }
    }
}
