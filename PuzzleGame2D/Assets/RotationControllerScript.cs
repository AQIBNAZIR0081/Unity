using UnityEngine;
using UnityEngine.UI;

public class RotationControllerScript : MonoBehaviour
{
    public Transform[] pictures;
    public static bool WinFlag;

    private float rotationThreshold = 0.001f;

    public Text WinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinFlag = false;
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        bool allWithinThreshold = true;
        for (int i = 0; i < pictures.Length; i++)
        {
            if (pictures[i].rotation.z >= rotationThreshold)
            {
                allWithinThreshold = false;
                break;
            }
        }

        if (allWithinThreshold)
        {
            WinFlag = true;
            WinText.text = "YOU WIN";
        }
    }
}
