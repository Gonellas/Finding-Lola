using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    public GameObject[] allMenues;
    public GameObject wantedActiveMenu;

    private void Start()
    {
        //Si el menu activado es mayor a 0 (elemento 1 en la lista)
        if(allMenues.Length > 0)
        {
            //Recorre la lista y desactiva los menues activados
            foreach (GameObject menu in allMenues)
            {
                menu.SetActive(false);
            }
        }

        //Si el menu principal no está activado, activalo
        if (wantedActiveMenu != null) wantedActiveMenu.SetActive(true);
    }

    public void ChangeScene(Object scene)
    {
        //Cambio de escena
        SceneManager.LoadScene(scene.name);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        //Si estamos en el editor, cerrá el juego con este código
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
