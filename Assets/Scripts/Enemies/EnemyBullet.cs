using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public float bulletDamage = 25f;
    private Transform target;
    public Animator playerDamaged;
    public GameManager gameManager;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        playerDamaged = GameObject.FindWithTag("Player").GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        transform.position += speed * transform.right * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerDamaged.SetTrigger("isDamaged");
            
            collision.gameObject.GetComponent<PlayerLife>().GetDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
