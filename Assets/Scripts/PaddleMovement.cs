using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float minx = 1f;
    [SerializeField] float maxx = 15f;
    [SerializeField] float mousePositionInUnit = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xpositionofmouse = Input.mousePosition.x / Screen.width * mousePositionInUnit;
        Vector2 paddlePos = new Vector2(Mathf.Clamp(xpositionofmouse, minx, maxx), transform.position.y);
        
        transform.position = paddlePos;
    }
}
