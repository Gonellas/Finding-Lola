using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCanvas : MonoBehaviour
{
    public Image lifeBar;

    public void UpdateLife(float life, float maxLife)
    {
        lifeBar.fillAmount = life / maxLife;
    }
}
