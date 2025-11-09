using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject shopIndicator;

    public PlayerShooting playerShootingS;

    public bool shopIndicatorVisible;

    public bool isInShop;

    void Start()
    {
        shopUI.SetActive(false);
        shopIndicator.SetActive(false);
    }

    void Update()
    {
        if (shopIndicatorVisible)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0f;
                isInShop = true;
                playerShootingS.canShoot = false;
                shopUI.SetActive(true);
                shopIndicator.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                isInShop = false;
                playerShootingS.canShoot = true;
                shopUI.SetActive(false);
                shopIndicator.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopIndicator.SetActive(true);
            shopIndicatorVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopIndicator.SetActive(false);
            shopIndicatorVisible = false;
        }
    }
}
