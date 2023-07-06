using System.Collections;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    public GameObject mark;
    public GameObject interact;
    public GameObject[] dialoguesObjects;
    public int dialogueIndex;
    public bool isPlayerInRange;    
    public bool didDialogueStart;   

    private void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else
            {
                NextDialogue();
            }
        }
    }

    private void StartDialogue()
    {

        didDialogueStart = true;
        Time.timeScale = 0;
        mark.SetActive(false);
        ShowDialogue();
    }

    private void NextDialogue()
    {
        dialoguesObjects[dialogueIndex].SetActive(false);
        dialogueIndex++;

        if (dialogueIndex < dialoguesObjects.Length)
        {
            ShowDialogue();
        }
        else if(dialogueIndex >= dialoguesObjects.Length)
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        didDialogueStart = false;
        Time.timeScale = 1;
        mark.SetActive(false);
        Destroy(mark);
        Destroy(interact);
    }


    private void ShowDialogue()
    {
        foreach (GameObject dialogueObject in dialoguesObjects)
        {
            dialogueObject.SetActive(false);
        }

        dialoguesObjects[dialogueIndex].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            mark.SetActive(true);
        }
    }
      

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            mark.SetActive(false);
            if (didDialogueStart)
            {
                EndDialogue();
            }
        }
    }
}
