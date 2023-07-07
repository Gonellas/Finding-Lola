using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour
{

    public FollowEnemy followEnemy;
    public PatrolAndFollowEnemy patrolAndFollowEnemy;
    SpriteRenderer mySprite;
    public Color playerNotSeen, playerSeen;

    private void Start()
    {
        //mySprite= GetComponent<SpriteRenderer>();
        //mySprite.color = new Color(0.2891153f, 0.8396226f, 0.6926575f, 0.3921569f);
        //mySprite.color = playerNotSeen;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerSpotted();
            //mySprite.color = new Color(0.9433962f, 0.004449993f, 0.09141554f, 0.3921569f);
            //mySprite.color = playerSeen;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerSpotted();
            //mySprite.color = new Color(0.2891153f, 0.8396226f, 0.6926575f, 0.3921569f);
            //mySprite.color = playerNotSeen;
        }

    }
    void playerSpotted ()
    {
        if (followEnemy != null) followEnemy.PlayerHasBeenSeen();
        if (patrolAndFollowEnemy != null) patrolAndFollowEnemy.PlayerHasBeenSeen();
    }

}

