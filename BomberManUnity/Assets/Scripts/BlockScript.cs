using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField]
    GameObject prefabsBonus;


    private void OnDestroy()
    {
        if(Random.Range(0,10) < 2)
        {
            Instantiate(prefabsBonus,transform.position,Quaternion.identity);
        }
    }
}
