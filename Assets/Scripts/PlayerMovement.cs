using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("ForMouseInput")]
    [SerializeField] private float SensX;
    private float yRotation;


    [Header("Movement")]
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private Transform orientation;
    private float hInput;
    private float vInput;
    private Vector3 moveDir;
    private Rigidbody rb;


    [Header("GroundCheck")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask WhatIsGround;
    private bool grounded;


    [Header("GameInputHandler")]

    [SerializeField] private GameInput gameInput;
    private string finalGateTag = "FinalGate"; // Tag of the cube

    
    //for final gate
    private GameObject finalGateObject;
    private float winRange = 2.7f; // Range within which player wins


    //for spawning
    [SerializeField] private Vector3 spawningPositon = new Vector3(5.8f, -2f, -35f);

    public ManageScenes sm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        finalGateObject = GameObject.FindGameObjectWithTag(finalGateTag);
        if(finalGateObject == null) {
            Debug.LogError("Cube not found with tag: " + finalGateTag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the gate distance
        // Debug.Log("Distance from the gate: " + Vector3.Distance(transform.position, finalGateObject.transform.position));

        // Check if the player is within win range of the cube
        if (distanceBetweenPlayerAndGate() <= winRange)
        {
            GameManager.Instance.hasPlayerReached(true);
        }
        
        GameManager.Instance.hasPlayerReached(false);

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);

        playerRotation();
        MyInput();
        SpeedControl();

        if(grounded) {
            rb.drag = groundDrag;
        } else {
            rb.drag = 0;
        }
    }

    public float distanceBetweenPlayerAndGate() {
        return Vector3.Distance(transform.position, finalGateObject.transform.position);
    }

    void FixedUpdate() {
        if (grounded) {
            MovePlayer();
        }
    }

    private void MyInput(){
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer(){
        moveDir = orientation.forward * vInput + orientation.right * hInput;
        rb.AddForce(moveDir.normalized * MovementSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > MovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MovementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    // TODO: Handle this using gameinput
    void playerRotation(){
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensX;
        yRotation += mouseX;
        Vector3 targetRotation = new Vector3(transform.rotation.x, yRotation, transform.rotation.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), MovementSpeed * Time.deltaTime);
        // transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }


    // Refactored code:
    public void spawnAtSpawnPosition() {
        transform.position = new Vector3(spawningPositon.x, spawningPositon.y, spawningPositon.z);
    }

    private void OnDestroy() {
        sm.onGameOver();    
    }
}
