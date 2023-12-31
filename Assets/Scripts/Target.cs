using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 50f;
    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0f)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
