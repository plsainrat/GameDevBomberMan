using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovments : MonoBehaviour
{

    private float horizontalMvmnt;
    private float verticalMvmnt;
    private float speed;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMvmnt = Input.GetAxis("Horizontal");
        verticalMvmnt = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalMvmnt * speed, verticalMvmnt * speed);
    }
}
