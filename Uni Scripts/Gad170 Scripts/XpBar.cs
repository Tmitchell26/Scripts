using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public int maxXp;

    public void SetMinXp(int xp)
    {
        slider.minValue = xp;
        slider.value = xp;
    }

    public void SetXP(int xp)
    {
        slider.value = xp;
    }

    public void SetMaxXp(int maxXp)
    {
        slider.maxValue = maxXp;
    }
}
