using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Delivery : MonoBehaviour
    {
        [SerializeField] float destroyDelay = 0.2f;
        [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
        [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
        [SerializeField] AudioClip CarSound;
        [SerializeField] AudioClip PackageSound;
        [SerializeField] AudioClip PackageDeliverSound;
        
        CashSystem cashSystem;
        PackagesManager packagesManager;

        SpriteRenderer spriteRenderer;
        AudioSource audioSource;
        bool hasPackage;

        // Start is called before the first frame update
        void Start()
        { 
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }

            if (cashSystem == null)
                cashSystem = FindAnyObjectByType<CashSystem>();

            if(packagesManager == null)
                packagesManager = FindAnyObjectByType<PackagesManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Package" && !hasPackage)
            {
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                audioSource.PlayOneShot(PackageSound);
                Destroy(collision.gameObject, destroyDelay);
            }
            else if (collision.tag == "Customer" && hasPackage)
            {
                hasPackage = false;
                audioSource.PlayOneShot(PackageDeliverSound);
                spriteRenderer.color = noPackageColor;
                cashSystem?.AddCash(); // Add cash when delivering the package
                packagesManager?.UpdatePackageCount(); // Update package count in PackagesManager
            }
        }

    }
}