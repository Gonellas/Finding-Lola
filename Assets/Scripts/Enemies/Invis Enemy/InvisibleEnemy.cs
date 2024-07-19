using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvisibleEnemy : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteR;


    public FollowEnemy followEnemy;
    public PatrolAndFollowEnemy patrolAndFollowEnemy;
    public Color playerNotSeen, playerSeen;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerSpotted();
            Color color = spriteR.color;
            color.a = 255f;
            spriteR.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerSpotted();
            Color color = spriteR.color;
            color.a = 0f;
            spriteR.color = color;
        }

    }
    void playerSpotted()
    {
        if (followEnemy != null) followEnemy.PlayerHasBeenSeen();
        if (patrolAndFollowEnemy != null) patrolAndFollowEnemy.PlayerHasBeenSeen();
    }
}