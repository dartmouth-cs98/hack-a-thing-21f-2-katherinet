using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if space key is hit
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyWasPressed = true;
        }

        // check for 
        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate() {
        if (!isGrounded) {
            return;
        }

        // up down velocity
        if (jumpKeyWasPressed) {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        // horizontal velocity
        rigidBodyComponent.velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision) {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision) {
        isGrounded = false;
    }
}
