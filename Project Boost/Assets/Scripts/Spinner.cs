using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 0f;
    [SerializeField] float yAngle = 0f;
    [SerializeField] float zAngle = 0f;
    [SerializeField] float speed = 1f;

    Animator animate;

    // Start is called before the first frame update
    void Start(){
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1) {
            animate.enabled = false;
            transform.Rotate(xAngle * speed, yAngle * speed, zAngle * speed);
        }
    }
}
