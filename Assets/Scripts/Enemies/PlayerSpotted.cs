using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    */

    public FollowEnemy followEnemy;
    SpriteRenderer mySprite;

    private void Start()
    {
        mySprite= GetComponent<SpriteRenderer>();
        mySprite.color = new Color(0.2891153f, 0.8396226f, 0.6926575f, 0.3921569f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            followEnemy.PLayerHasBeenSeen();
            mySprite.color = new Color(0.9433962f, 0.004449993f, 0.09141554f, 0.3921569f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            followEnemy.PLayerHasBeenSeen();
            mySprite.color = new Color(0.2891153f, 0.8396226f, 0.6926575f, 0.3921569f);
        }

    }
}
