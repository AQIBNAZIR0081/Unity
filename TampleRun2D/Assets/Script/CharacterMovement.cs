using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float runSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true;

    private AudioSource audioSource;
    private Coroutine slideCoroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isSliding", false);

        audioSource.Play();
        audioSource.loop = true; // Loop the audio
    }

    void Update()
    {

        // Run
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("isRunning", true);
            rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            animator.SetBool("isJumping", true);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Desert"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);

            // Start the slide animation for 1 second
            if (slideCoroutine != null)
                StopCoroutine(slideCoroutine);

            slideCoroutine = StartCoroutine(PlaySlideAnimation());
        }
    }

    private IEnumerator PlaySlideAnimation()
    {
        animator.SetBool("isSliding", true);
        yield return new WaitForSeconds(1f); // slide for 1 second
        animator.SetBool("isSliding", false);
        animator.SetBool("isRunning", false); // switch to idle
    }
}
