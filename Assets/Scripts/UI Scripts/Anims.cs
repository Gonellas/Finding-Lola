using UnityEngine;

public class Anims : MonoBehaviour
{
    public GameObject animObject;
    public GameObject animObjectTrigger;
    public Animator animObjectAnim;

    private void Start()
    {
        animObjectAnim = animObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animObject.SetActive(true);
            animObjectAnim.SetBool("isAnim", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animObject.SetActive(false);
            Destroy(animObjectTrigger);
        }
    }
}
