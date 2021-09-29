using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;

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
        // if the player is not overlapping with anything (aka in the air)
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) {
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
}
