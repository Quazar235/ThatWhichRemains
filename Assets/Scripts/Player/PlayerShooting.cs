using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;

    public GameObject seed;
    public Transform seedTransform;

    public bool canShoot;
    private float timer;
    public float shootCooldown;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        TrackRotation();

        Shoot();
    }

    private void TrackRotation()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void Shoot()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > shootCooldown)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Instantiate(seed, seedTransform.position, Quaternion.identity);
        }
    }
}
