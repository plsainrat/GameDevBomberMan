using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    private void OnDestroy()
    {
        gameManager.active = true; 
    }
}
