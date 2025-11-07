using System;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    void Update()
    {
        Debug();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Time.timeScale = 0f;
        print("OOF");
    }

    private void Debug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TakeDamage(10);
        }
    }
}
