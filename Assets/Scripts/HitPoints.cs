using System;
using System.Collections;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    public const int MAX = 100;
    public const uint HEALING = 1;

    private int value;
    private uint healingFactor;

    void Start ()
    {
        value = MAX;
        healingFactor = HEALING;
    }

    private void Update()
    {
        value = Math.Min(MAX, value + (int)healingFactor);
    }

    public void Damage(int damageVal)
    {
        value = Math.Max(0, value - damageVal);
        if (value == 0) Die();
    }

    public void Heal(int healVal)
    {
        value = Math.Min(MAX, value + healVal);
    }

    public int GetValue()
    {
        return value;
    }

    public void Die()
    {
        CancelInvoke();

        Debug.Log("Dead");
    }
}
