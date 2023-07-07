using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject enemy;
    public GameObject trigger;
    private bool hasTriggered = false;

    private void Start()
    {
        if (enemy == null)
        {
            ActivateTrigger();
        }
    }

    private void Update()
    {
        if (enemy == null && !hasTriggered)
        {
            ActivateTrigger();
        }
    }

    private void ActivateTrigger()
    {
        trigger.SetActive(true);
        hasTriggered = true;
    }
}
