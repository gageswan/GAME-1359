using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public AudioClip HeartClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Camera cam;
    public Transform player;


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }

    private float startTime;
    private float journeyLength;

    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
            if(currentHealth <= 20 && !isDead){
                playerAudio.clip = HeartClip;
                playerAudio.Play();
                playerAudio.loop = true;
            }
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (isDead) {
            float distCovered = (Time.time - startTime) * .1f;

            float fractionOfJourney = distCovered / journeyLength;

            cam.gameObject.GetComponent<CameraFollow>().enabled = false;            
            Vector3.Lerp(cam.transform.position, player.position, fractionOfJourney);
        }
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        float x = (cam.transform.position.x + Random.Range(-.05f, .05f));
        float y = (cam.transform.position.y + Random.Range(-.05f, .05f));

        cam.transform.position = new Vector3(x, y, transform.position.z);

        if (currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.loop = false;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;

        startTime = Time.time;
        journeyLength = Vector3.Distance(cam.transform.position, player.position);
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
