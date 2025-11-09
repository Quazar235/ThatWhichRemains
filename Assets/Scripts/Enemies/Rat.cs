using UnityEngine;

public class Rat : MonoBehaviour
{
    PlayerShooting playerShootingS;
    PlayerHealth playerHealthS;
    Animator animator;

    public GameObject batteryPrefab;
    
    public int maxHealth = 10;
    public int currentHealth;

    public GameObject posA;
    public GameObject posB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        playerShootingS = GameObject.FindGameObjectWithTag("Rotate Point").GetComponent<PlayerShooting>();
        playerHealthS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentPoint = posB.transform;


        currentHealth = maxHealth;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == posB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == posB.transform)
        {
            Flip();
            currentPoint = posA.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == posA.transform)
        {
            Flip();
            currentPoint = posB.transform;
        }
    }

    private void TakeDamage(int damage)
    {
        animator.SetBool("Hit", true);
        Invoke("ReturnColour", 0.1f);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Instantiate(batteryPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            TakeDamage(playerShootingS.seedDamage);
        }
        if (collision.CompareTag("Player"))
        {
            playerHealthS.TakeDamage(2);
        }
    }

    public void ReturnColour()
    {
        animator.SetBool("Hit", false);
    }
}
