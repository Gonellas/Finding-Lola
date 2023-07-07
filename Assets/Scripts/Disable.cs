using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    public GameObject enemy;
    StaticEnemy staticEnemy;
    public GameObject[] messages;
    private int currentIndex = 0;
    public GameObject messagesTrigger;
    private bool isInteracting = false;

    private void Start()
    {
        staticEnemy = enemy.GetComponent<StaticEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            DisableScript();
            isInteracting = true;
            SetMessageActive(currentIndex, true);
        }
    }

    private void DisableScript()
    {
        if (staticEnemy != null)
        {
            staticEnemy.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Time.timeScale = 1;
        staticEnemy.enabled = true;
        Destroy(messagesTrigger);
        isInteracting = false;
    }

    private void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            SetMessageActive(currentIndex, false);
            currentIndex++;
            if (currentIndex >= messages.Length)
            {
                Time.timeScale = 1;
                currentIndex = 0;
                isInteracting = false;
                Destroy(messagesTrigger);
                return;
            }
            SetMessageActive(currentIndex, true);
        }
    }

    private void SetMessageActive(int index, bool isActive)
    {
        if (index >= 0 && index < messages.Length)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                messages[i].SetActive(i == index && isActive);
            }
        }
    }
}