using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droper : MonoBehaviour
{
    MeshRenderer m_MeshRenderer;
    Rigidbody rb;
    [SerializeField] float timeToWait = 4f;
    // Start is called before the first frame update
    private void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_MeshRenderer.enabled = false;
        rb = GetComponent<Rigidbody>(); 
        rb.useGravity = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time > timeToWait ) {
            m_MeshRenderer.enabled = true;
            rb.useGravity = true;
        }
        
    }
}
