using UnityEngine;

public class Messages : MonoBehaviour
{
    [SerializeField] GameObject _messagesCanva;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _messagesCanva.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _messagesCanva.SetActive(false);
        }
    }
}
