using UnityEngine;

public class RotationSprite : MonoBehaviour
{
    private int[] rotationAngles = { 90, -90, 180, -180 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int RandomAngle = Random.Range(0, 3);
        transform.Rotate(0, 0, rotationAngles[RandomAngle]);
    }

    private void OnMouseDown()
    {
        if (!RotationControllerScript.WinFlag)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
