using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour {
    [SerializeField] float delayTime = 1.0f;
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
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }

    private void StartCrashSequence() {
        Movement movement = GetComponent<Movement>();
        if (movement != null) {
            movement.enabled = false;
        }
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
