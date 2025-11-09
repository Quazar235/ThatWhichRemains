using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip music;
    AudioSource audioSource;
    [SerializeField] bool playMusic = false;
    float defaultVolume = 0.2f;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (playMusic)
        {
            PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayMusic()
    {
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }
}