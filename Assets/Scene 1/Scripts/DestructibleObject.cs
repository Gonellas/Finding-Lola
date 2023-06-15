using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    //Contador de golpes
    public int hitsBeforeDestroy = 1;

    public void GetDamage()
    {
        hitsBeforeDestroy--;

        if (hitsBeforeDestroy <= 0)
        {
            DestroyObject();            
        }
        else
        {
            Debug.Log(gameObject.name + " recibi� da�o, le quedan " + hitsBeforeDestroy + "hits");
        }
    }

    public void DestroyObject()
    {
        Debug.Log(gameObject.name + " se destruy�");
        Destroy(gameObject);
    }
}
