using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;
    float vertical;
    float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
