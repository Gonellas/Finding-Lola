using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject interact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife _playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (_playerLife.playerLife < _playerLife.playerMaxLife)
            {
                interact.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interact.SetActive(false);
        }
    }
}