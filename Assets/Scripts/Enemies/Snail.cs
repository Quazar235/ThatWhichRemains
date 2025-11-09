using UnityEngine;

public class Snail : MonoBehaviour
{
    public GameObject lava;
    public Transform lavaPos;

    private float timer;

    private GameObject player;

    public int currentHealth;
    public int maxHealth = 30;

    public SpriteRenderer sr;
    public PlayerShooting playerShootingS;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        currentHealth = maxHealth;
    }

    void Update()
    {
        float lavaRange = Vector2.Distance(transform.position, player.transform.position);

        if (lavaRange < 10)
        {
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                timer = 0f;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(lava, lavaPos.position, Quaternion.identity);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        TintRed();
        if (currentHealth <= 0)
        {
            playerShootingS.BossesBeaten();
            Destroy(gameObject);
        }
    }

    void TintRed()
    {
        sr.color = Color.red;
        Invoke("TintWhite", 0.1f);
    }

    void TintWhite()
    {
        sr.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            TakeDamage(playerShootingS.seedDamage);
        }
    }
}
