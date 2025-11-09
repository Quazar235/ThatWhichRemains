using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;

    public GameObject seed;
    public Transform seedTransform;

    public bool canShoot;
    private float timer;
    public float shootCooldown;

    public int canBlank;

    public int seedDamage = 1;
    public GameObject pauseMenu;
    public bool isPaused = false;

    public Shop shopS;

    bool dialoguePause = false;

    public int bossesBeaten = 0;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        TrackRotation();

        Shoot();

        Blank();
        PauseMenu();
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

    public void Blank()
    {
        if (Input.GetMouseButtonDown(1) && canBlank > 0)
        {
            print("blank");
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Seed"))
            {
                Destroy(gameObj);
            }
        }
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && !shopS.isInShop)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && !shopS.isInShop)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ResumeGameButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void DialoguePaused()
    {
        dialoguePause = true;
    }

    public void DialogueOnPause()
    {
        dialoguePause = false;
    }

    public void BossesBeaten()
    {
        bossesBeaten++;
    }
}
