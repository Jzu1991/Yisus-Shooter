using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); 
    }

    // Salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }
}
