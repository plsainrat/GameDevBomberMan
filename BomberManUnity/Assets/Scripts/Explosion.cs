using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Collider2D coll;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        Invoke("Exploding", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void Exploding()
    {
        Destroy(gameObject);
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Debug.Log("Death");
                Destroy(collision.gameObject);
                break;
            case "Bomb":
                Debug.Log("Bomb");
                collision.gameObject.GetComponent<Bomb>().Explode();
                break;
            default:
                break;

        }
    }


}
