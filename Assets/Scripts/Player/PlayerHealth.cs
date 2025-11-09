using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    [SerializeField] Image healthBar;

    public Transform respawnPoint;
    public Transform playerTransform;

    void Start()
    {
        maxHealth = 10;
        currentHealth = maxHealth;
    }

    void Update()
    {
        Debug();
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void GainHealth(int health)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += health;
        }
    }

    public void Death()
    {
        print("OOF");
        playerTransform.position = respawnPoint.position;
        currentHealth = maxHealth;
        
    }

    public void DoubleMaxHealth()
    {
        maxHealth = 20;
    }

    private void Debug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TakeDamage(1);
        }
    }

    private void UpdateHealthBar()
    {
        float pixelWidth = currentHealth * 16;
        float fillVal = pixelWidth / 320;
        healthBar.fillAmount = fillVal;
    }
}
