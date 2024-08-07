using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hitCount = 0;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Hit") {
            hitCount++;
            Debug.Log("You bumped into a thing this many times: " + hitCount );
        }
    }
}
