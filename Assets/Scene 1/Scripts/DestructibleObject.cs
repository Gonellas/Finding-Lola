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
            Debug.Log(gameObject.name + " recibió daño, le quedan " + hitsBeforeDestroy + "hits");
        }
    }

    public void DestroyObject()
    {
        Debug.Log(gameObject.name + " se destruyó");
        Destroy(gameObject);
    }
}
