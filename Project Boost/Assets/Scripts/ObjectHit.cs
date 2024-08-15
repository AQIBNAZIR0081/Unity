using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Object.Destroy(gameObject);
            gameObject.tag = "Hit";
        }

        switch (collision.gameObject.tag) {
            case "Respawn":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Invoke("LoadNextLevel", delayTime);
                break;
            case "Hit":
                Debug.Log("You get the fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence() {
        GetComponent<Movement>().enabled = false;
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
