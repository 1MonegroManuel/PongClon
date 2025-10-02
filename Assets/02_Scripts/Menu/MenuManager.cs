using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Método para ir a la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    // Método para salir de la aplicación
    public void QuitGame()
    {
        // En el editor de Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // En la aplicación compilada
            Application.Quit();
        #endif
    }
}
