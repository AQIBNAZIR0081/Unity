using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Delivery : MonoBehaviour
    {
        bool hasPackage;
        [SerializeField] float destroyDelay = 0.5f;
        [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
        [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

        SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    Debug.Log("Collision detected with: " + collision.gameObject.name);
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Package" && !hasPackage)
            {
                Debug.Log("PickUp " + collision.gameObject.name);
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(collision.gameObject, destroyDelay);
            }
            else if (collision.tag == "Customer" && hasPackage)
            {
                Debug.Log("Found " + collision.gameObject.name);
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
        }
    }
}