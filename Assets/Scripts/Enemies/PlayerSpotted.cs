using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour
{

    public FollowEnemy followEnemy;
    public PatrolAndFollowEnemy patrolAndFollowEnemy;
    public Color playerNotSeen, playerSeen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerSpotted();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerSpotted();
        }

    }
    void playerSpotted ()
    {
        if (followEnemy != null) followEnemy.PlayerHasBeenSeen();
        if (patrolAndFollowEnemy != null) patrolAndFollowEnemy.PlayerHasBeenSeen();
    }
}

