using UnityEngine;
using UnityEngine.Playables;

public class DialogManager : MonoBehaviour
{
    private PlayableDirector playableDirector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        if (playableDirector != null)
        {
            // Optionally, you can start the timeline here or set it up for later use
            playableDirector.Play();
        }
    }

}
