using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    private bool dropBomb=false;
    public GameObject bombprefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dropBomb = true;
        }
    }

    private void FixedUpdate()
    {
        if (dropBomb)
        {
            float snapx = Mathf.Round(gameObject.transform.position.x);// + 0.5f;
            float snapy = Mathf.Round(gameObject.transform.position.y);// + 0.5f;
            Instantiate(bombprefab, new Vector2(snapx, snapy), Quaternion.identity);
            dropBomb = false;
        }
    }
}
