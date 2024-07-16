using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject defeatedMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tutorialCompletedMenu;

    [SerializeField] List<GameObject> _enemiesToDefeat;

    private bool isPaused = false;
    public AudioSource audioSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        PauseMenu(isPaused);
    }

    public void PauseMenu(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void DefeatedMenu()
    {
        defeatedMenu.SetActive(true);
        audioSource.Play();
        Time.timeScale = 0;
        isPaused = true;
    }

    public void EnemyDefeated(GameObject enemy)
    {
        _enemiesToDefeat.Remove(enemy);
        CheckTutorialCompleted();
    }

    private void CheckTutorialCompleted()
    {
        if (_enemiesToDefeat.Count == 0)
        {
            tutorialCompletedMenu.SetActive(true);
        }
    }
}
