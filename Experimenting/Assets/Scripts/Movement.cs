using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Movement : MonoBehaviour {

    /*[SerializeField] private float moveSpeed = 7f;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * 200);
        }
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }*/
    [SerializeField] private float moveSpeed = 7f;

    private void Start() {

    }
    private void Update() {
        PlayerMovement();
    }

    private void PlayerMovement() {

        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);

    }
}
