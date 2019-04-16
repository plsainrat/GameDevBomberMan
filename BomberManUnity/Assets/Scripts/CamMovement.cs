using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    float maxX = 10f;
    float maxY = 10f;
    float camWidth;
    float camHeight;
    
    Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
        camHeight = playerCam.orthographicSize * 2f;
        camWidth = camHeight * playerCam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x + camWidth >= maxX)
        {
            transform.position = new Vector2( maxX - camWidth, 0 );
        }
        if (transform.position.y + camWidth >= maxY)
        {
            transform.position = new Vector2(0,maxY - camHeight);
        }
        if (transform.position.x - camWidth <= -maxX)
        {
            transform.position = new Vector2(maxX + camWidth, 0);
        }
        if (transform.position.x - camHeight <= -maxY)
        {
            transform.position = new Vector2(maxX + camHeight, 0);
        }
    }
}
