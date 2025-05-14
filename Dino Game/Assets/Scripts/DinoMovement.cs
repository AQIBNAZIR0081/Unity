using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    public CharacterController2D controller;
    bool jump = false;
    bool crouch = false;

    float leftMove = -20f;
    float RightMove = 20f;

    public float maxhealthValue = 100;
    float currentHealth;

    public Slider HealthSlider;

    float scoreValue = 0;
    public Text ScoreText;

    public AudioSource audiosource;
    public AudioClip appleBitingSound;
    public AudioClip CoinCollectionSound;
    public GameObject replayPannel;
    public GameObject cloud;

    private Touch mobileScreenTouch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        //for health slider
        currentHealth = maxhealthValue;
        HealthSlider.maxValue = maxhealthValue;
        HealthSlider.value = currentHealth;
        //for score 
        ScoreText.text = "Score: " + scoreValue.ToString();
        audiosource.GetComponent<AudioSource>();

        replayPannel.SetActive(false);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //For left and right movement
        if(mobileScreenTouch.tapCount > 0)
        {
            mobileScreenTouch = Input.GetTouch(0);
            Debug.Log("Touch position:" + mobileScreenTouch.position);
            if (mobileScreenTouch.phase == TouchPhase.Moved)
            {
                controller.Move(RightMove * Time.fixedDeltaTime, crouch, jump);
                anim.SetBool("isWalking", true);
                currentHealth -= .5f;
                HealthSlider.value = currentHealth;
            }
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(leftMove * Time.fixedDeltaTime, crouch, jump);
            anim.SetBool("isWalking",true);
            currentHealth -= .5f;
            HealthSlider.value = currentHealth;
        }
    }

    private void Update()
    {
        //for Jump
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.up * 10 * Time.fixedDeltaTime);
            anim.SetBool("isJumping",true);
        }
        if (currentHealth <= 0)
        {
            anim.SetBool("isDead",true);
            replayPannel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print(currentHealth);
            currentHealth -= .5f;
            HealthSlider.value = currentHealth;


            if (currentHealth <= 10)
            {
                anim.SetBool("isDead", true);
                replayPannel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (collision.gameObject.name.StartsWith("Apple"))
        {
            audiosource.PlayOneShot(appleBitingSound);
            currentHealth += 3;
            HealthSlider.value = currentHealth;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.name.StartsWith("Coin"))
        {
            audiosource.PlayOneShot(CoinCollectionSound);
            scoreValue += 5;
            ScoreText.text = "Score :" + scoreValue.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.StartsWith("BigApple"))
        {
            audiosource.PlayOneShot(appleBitingSound);
            currentHealth += 50;
            HealthSlider.value = currentHealth;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.StartsWith("Cloud"))
        {
            transform.gameObject.transform.parent = cloud.transform; //dino will become child of cloud
        }

        else
        {
            transform.gameObject.transform.parent = null; //dino will become independant
        }
    }

}