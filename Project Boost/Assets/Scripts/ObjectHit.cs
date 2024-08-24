using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] float delayTime = 2.0f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem crashParticles;


    AudioSource audioSource;
    Movement movement;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Respawn":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence() {
        movement.enabled = false;
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", delayTime);     
    }

    private void StartCrashSequence() {
        if (movement != null) {
            movement.enabled = false;
        }
        crashParticles.Play();
        audioSource.PlayOneShot(crash);
        Invoke("ReloadLevel", delayTime);
    }

    private void LoadNextLevel() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentLevel + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadLevel() { 
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
