using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillUpdateLife : MonoBehaviour
{
    public Image uiImageHealth;

    private void OnValidate()
    {
        if (uiImageHealth == null)
        {
            uiImageHealth.GetComponent<Image>();
        }
    }
    public void UpdateValue(float f)
    {
        uiImageHealth.fillAmount = f;

    }

    public void UpdateValue(float max, float current)
    {
        uiImageHealth.fillAmount = 1 - (current / max);

    }
}
