using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        if (enemies.Length == 0)
        {
            LoadVictoryScene();
        }
    }
    void LoadVictoryScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Victory");
    }
}
