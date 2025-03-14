using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    private bool isMoving;
    private GameObject currentEnterArea;
    private int initialCount = 0;
    private int MaxChildCount = 30;

    public float maxHealth = 50f;
    public float carSpeed = 400f;
    public float rotationSpeed = 500f;

    public AudioClip BusSound;
    public AudioClip HornSound;

    public Text HealthText;
    public Text ChildCountText;
    public GameObject WinningPanel;
    
    AudioSource audioSource;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        HealthText.text = "Health: " + maxHealth.ToString();
        ChildCountText.text = "Child Count: " + initialCount.ToString();
        WinningPanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        GameWinning();
    }

    private void Movement()
    {
        // Move in Forward Direction
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * carSpeed, ForceMode.Force);
            PlaySound(BusSound);
        }

        // Move in Backward Direction
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * carSpeed, ForceMode.Force);
            PlaySound(BusSound);
        }

        // Move in Right Direction
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * rotationSpeed, ForceMode.Force);
            
        }

        // Move in Left Direction
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * rotationSpeed, ForceMode.Force);
            
        }


        // Horn Sound
        if (Input.GetKey(KeyCode.H))
        {
            PlaySound(HornSound);
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            StopSound(HornSound);
        }

        // On Pressing Space Collect Children
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PickingUpChild();
        }

    }


    // Collide with other Objects
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Buildings") || collision.gameObject.CompareTag("Vehicles"))
        {
            Debug.Log("Collision Detection");
            UpdateHealth();
            if (maxHealth <= 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    // Trigger Enter for Getting Child
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnterArea"))
        {
            currentEnterArea = other.gameObject;    // assign currentEnterArea to other gameObject
        }
    }

    private void PickingUpChild()
    {
        if (currentEnterArea != null)
        {
            int childCount = currentEnterArea.transform.childCount;    // Count of Children of Object Parent
            initialCount += childCount;      // Initial Count of Children

            if (initialCount <= MaxChildCount)
            {
                ChildCountText.text = "Child Count: " + initialCount + "/" + MaxChildCount;
                for (int i = 0; i < childCount; i++)   // Loop through all the children of the Object Parent
                {
                    Destroy(currentEnterArea.transform.GetChild(i).gameObject);  // Destroy the Children
                }
            }
        }
    }


    // Play Sound
    private void PlaySound(AudioClip audio)
    {
        audioSource.playOnAwake = false;
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audio;
            audioSource.Play();
            isMoving = true;
        }
    }

    // Stop Sound
    private void StopSound(AudioClip audio)
    {
        audioSource.playOnAwake = false;
        if (audioSource.isPlaying && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)))
        {
            audioSource.Stop();
            isMoving = false;
        }
    }

    private void UpdateHealth()
    {
        maxHealth -= 5; // Decrease Health by 5
        HealthText.text = "Health:" + maxHealth.ToString();
    }

    private void GameWinning()
    {
        if (initialCount == MaxChildCount)  // Check if all the children are collected
        {
            WinningPanel.SetActive(true);
        }
    }


}

