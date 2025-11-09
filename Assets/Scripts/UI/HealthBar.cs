using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealthS;

    public void UpdateBar()
    {
        healthSlider.value = playerHealthS.currentHealth;
    }
}
