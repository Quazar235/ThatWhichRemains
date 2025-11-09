using Unity.VisualScripting;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private GameObject player; 
    private Rigidbody2D rb; 
    public float oilSpeed;

    public PlayerHealth playerHealthS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        Vector3 Direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(Direction.x, Direction.y).normalized * oilSpeed;

        float oilRotation = Mathf.Atan2(-Direction.y, -Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, oilRotation + 90);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealthS.TakeDamage(3);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
