using UnityEngine;

public class Battery : MonoBehaviour
{
    PlayerCurrency playerCurrencyS;
    PlayerHealth playerHealthS;

    void Start()
    {
        playerCurrencyS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCurrency>();
        playerHealthS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCurrencyS.GainBatteries(1);
            playerHealthS.GainHealth(1);
            Destroy(gameObject);
        }
    }
}
