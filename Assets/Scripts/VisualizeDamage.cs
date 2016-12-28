using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeDamage : MonoBehaviour
{
    public GameObject character;

    private HitPoints hp;
    private Image blood;

    public void Start()
    {
        hp = character.GetComponent<HitPoints>();
        blood = GetComponent<Image>();
    }

    public void Update()
    {
        Color color = blood.color;
        float alpha = (float)(HitPoints.MAX - hp.GetValue()) / HitPoints.MAX;
        color.a = alpha;
        blood.color = color;
    }
}
