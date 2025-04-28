using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Collision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }
    }
}