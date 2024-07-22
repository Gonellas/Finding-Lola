using UnityEngine;

public class Healing : MonoBehaviour
{
    public float healingAmount = 50f;
    private bool isPlayerInRange = false;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        PlayerLife _playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();

        if (isPlayerInRange && _playerLife.playerLife < _playerLife.playerMaxLife)
        {
            if (Input.GetKey(KeyCode.E))
            {
                audioSource.Play();
                _playerLife.GetHeal(healingAmount);
                Destroy(gameObject);
            }
        }
        else
        {
            isPlayerInRange = false;
            Debug.Log("tengo toda la vida");
        }
    }
}
