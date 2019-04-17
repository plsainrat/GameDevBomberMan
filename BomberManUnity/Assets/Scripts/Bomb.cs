using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private Collider2D coll;
    private LayerMask blockLayer;


    [SerializeField]
    private GameObject prefabExplosion;

    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float bornTime;

    public int radius;





    // Start is called before the first frame update
    void Start()
    {
        bornTime = Time.time;
        coll = gameObject.GetComponent<Collider2D>();
        Invoke("Explode",lifeTime);
        blockLayer = LayerMask.GetMask("Block");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Explode()
    {
        Instantiate(prefabExplosion, (Vector2)transform.position, Quaternion.identity);
        StartCoroutine(Explosion(Vector2.down));
        StartCoroutine(Explosion(Vector2.left));
        StartCoroutine(Explosion(Vector2.right));
        StartCoroutine(Explosion(Vector2.up));
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coll.isTrigger = false;
        }
    }


    public IEnumerator Explosion(Vector2 dir)
    {
        for(int i=1; i <= radius;i++)
        {
            
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, dir,i, blockLayer);
           if(hit.collider!=null && hit.collider.gameObject.CompareTag("Destructible"))
            {
                Destroy(hit.collider.gameObject);
                Instantiate(prefabExplosion, (Vector2)transform.position + dir*i, Quaternion.identity).GetComponent<Collider2D>().enabled = false;
                break;
            }
            if(hit.collider == null)
            {
                Instantiate(prefabExplosion, (Vector2)transform.position + dir * i, Quaternion.identity);
            }
            else
            {
                break;
            }
        }

        yield return new WaitForSeconds(0.05f);
    } 
}
