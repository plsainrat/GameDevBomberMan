    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    private bool dropBomb=false;
    public GameObject bombprefab;

    public int numBombMax;
    public int radiusExplod;
    [SerializeField]
    private List<GameObject> bombs;

    // Start is called before the first frame update
    void Start()
    {
        numBombMax = 1;
        radiusExplod = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombs.Count < numBombMax)
        {
            dropBomb = true;
        }

        for (var i = bombs.Count - 1; i > -1; i--)
        {
            if (bombs[i] == null)
                bombs.RemoveAt(i);
        }

    }

    private void FixedUpdate()
    {
        if (dropBomb)
        {
            float snapx = Mathf.Floor(gameObject.transform.position.x) + 0.5f;
            float snapy = Mathf.Floor(gameObject.transform.position.y) + 0.5f;
            GameObject temp = Instantiate(bombprefab, new Vector2(snapx, snapy), Quaternion.identity);
            temp.GetComponent<Bomb>().radius = radiusExplod;
            bombs.Add(temp);
            dropBomb = false;
        }
    }
}
