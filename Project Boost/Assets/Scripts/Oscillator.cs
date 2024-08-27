using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 StartingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    float movementFactor;
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycle = Time.time / period; // continuoslly growing over time
        const float tau = Mathf.PI * 2;   // constant value of 6.28
        float rawSineWave = Mathf.Sin(cycle * tau); // going from -1 to 1
        movementFactor = (rawSineWave + 1f) / 2f; // recalculated to go from 0 to 1;

        Vector3 offset = movementVector * movementFactor;
        transform.position = StartingPosition + offset;
    }
}
