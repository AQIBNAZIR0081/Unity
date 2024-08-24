using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem LeftThruster;
    [SerializeField] ParticleSystem RightThruster;
    [SerializeField] ParticleSystem mainLeftThruster;
    [SerializeField] ParticleSystem mainRightThruster;


    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        if (Input.GetKey(KeyCode.W)) {
            StartThrusting();
        }
        else {
            audioSource.Stop();
            LeftThruster.Stop();
            RightThruster.Stop();
            mainLeftThruster.Stop();
            mainRightThruster.Stop();
        }
    }

    private void StartThrusting() {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!LeftThruster.isPlaying && !RightThruster.isPlaying) {
            LeftThruster.Play();
            RightThruster.Play();
        }
    }

    private void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(-rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(rotationThrust);
        }
        
    }

    private void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
