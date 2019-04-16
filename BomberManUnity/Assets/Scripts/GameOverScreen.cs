using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    private void Awake()
    {
        Invoke("ResetScene", 5f);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene("CombatScene");
    }
}
