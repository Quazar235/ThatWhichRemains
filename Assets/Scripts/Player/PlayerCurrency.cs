using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCurrency : MonoBehaviour
{
    public PlayerHealth playerHealthS;
    public PlayerShooting playerShootingS;
    public Battery batteryS;
    public TextMeshProUGUI batteryCounter;

    public GameObject CPU1;
    public GameObject CPU2;
    public GameObject CPU3;
    public GameObject CPU4;
    public GameObject CPU5;
    public GameObject CPU6;

    public int batteries;
    public bool doublePickups;

    void Start()
    {
        doublePickups = false;
    }

    void Update()
    {
        Debug();
    }

    public void GainBatteries(int amount)
    {
        if (doublePickups)
        {
            batteries += amount * 2;
            batteryCounter.text = batteries.ToString();
        }
        else if (!doublePickups)
        {
            batteries += amount;
            batteryCounter.text = batteries.ToString();
        }
    }

    public void DoubleHealth()
    {
        if (batteries >= 3)
        {
            playerHealthS.DoubleMaxHealth();
            batteries -= 3;
            batteryCounter.text = batteries.ToString();
            CPU1.SetActive(true);
        }
    }

    public void DoubleDamage()
    {
        if (batteries >= 3)
        {
            playerShootingS.seedDamage = 2;
            batteries -= 3;
            batteryCounter.text = batteries.ToString();
            CPU2.SetActive(true);
        }
    }

    public void LessCooldown()
    {
        if (batteries >= 3)
        {
            playerShootingS.shootCooldown = 0.2f;
            batteries -= 3;
            batteryCounter.text = batteries.ToString();
            CPU3.SetActive(true);
        }
    }

    public void DoublePickups()
    {
        if (batteries >= 3)
        {
            doublePickups = true;
            batteries -= 3;
            batteryCounter.text = batteries.ToString();
            CPU4.SetActive(true);
        }
    }

    public void DamageDash()
    {
        if (batteries >= 3)
        {
            
            batteryCounter.text = batteries.ToString();
            batteries -= 3;
            CPU5.SetActive(true);
        }

    }

    public void Blank()
    {
        if (batteries >= 3)
        {
            playerShootingS.canBlank += 1;
            batteries -= 3;
            batteryCounter.text = batteries.ToString();
            CPU6.SetActive(true);
        }
    }

    private void Debug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DoubleHealth();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DoubleDamage();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LessCooldown();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DoublePickups();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Blank();
        }
    }
}
