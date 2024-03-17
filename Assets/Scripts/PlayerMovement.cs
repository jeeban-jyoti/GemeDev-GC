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
    public float gravityStrength;
    private bool isGravity = true;


    [Header("GroundCheck")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask WhatIsGround;
    private bool grounded;


    [Header("GameInputHandler")]

    [SerializeField] private GameInput gameInput;
    private string finalGateTag = "FinalGate"; // Tag of the cube

    private string state = "MOVING";

    //for final gate
    private GameObject finalGateObject;
    private float winRange = 2.7f; // Range within which player wins
    public Enemy enemy;


    //for spawning
    [SerializeField] private Vector3 spawningPositon = new Vector3(5.8f, -2f, -35f);


    // Goto Rot
    public ManageScenes sm;
    public Transform rotatePoint;
    public float smoothSpeed = 0.125f;

    public PlayerCamMovement cam;

    Quaternion toRot;
    Quaternion fromRot;
    public float rotSpeed = 0.1f;
    float timeCount = 0.0f;

    public float cooldown = 10f;
    private bool canRotate = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // rb.useGravity = false;

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

        if(canRotate && state == "MOVING") {
            if (Input.GetKeyDown(KeyCode.K))
            {
                state = "GOTOROTATE_RIGHT";

                timeCount = 0;            
                toRot = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                fromRot = transform.rotation;

            } else if (Input.GetKeyDown(KeyCode.J)) {
                state = "GOTOROTATE_LEFT";

                timeCount = 0;            
                toRot = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                fromRot = transform.rotation;
            }
        }

        if(state == "GOTOROTATE_RIGHT") {    
            goToRotateRight();

            rotateObject();
        } else if (state == "GOTOROTATE_LEFT") {
            gotRotateLeft();

            rotateObject();
        } else if (state == "ROTATE_RIGHT") {
            StartCoroutine(WaitCooldown());
            rotateRight();
        } else if (state == "ROTATE_LEFT") {
            StartCoroutine(WaitCooldown());
            rotateLeft();
        } else if (state == "MOVING") {
            isGravity = true;
        }

    }

    private IEnumerator WaitCooldown() {
        canRotate = false;
        yield return new WaitForSeconds(cooldown);
        canRotate = true;
    }

    private void goToRotateRight() {
        Vector3 desiredPosition = rotatePoint.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        rb.useGravity = false;
    

        if((transform.position - desiredPosition).magnitude <= 1f) {
            state = "ROTATE_RIGHT";

            timeCount = 0;
            fromRot = transform.rotation;
            toRot = transform.rotation * Quaternion.Euler(0f, 0f, 90f);
         
        }
    }

    private void gotRotateLeft() {
        Vector3 desiredPosition = rotatePoint.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        rb.useGravity = false;
    

        if((transform.position - desiredPosition).magnitude <= 1f) {
            state = "ROTATE_LEFT";

            timeCount = 0;
            fromRot = transform.rotation;
            toRot = transform.rotation * Quaternion.Euler(0f, 0f, 270f);
               
        }
    }

    private void rotateRight() {
        rotateObject();

        if((transform.rotation.eulerAngles - toRot.eulerAngles).magnitude <= 1f) {
            state = "MOVING";
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            rb.useGravity = true;
            cam.Snap();
           GameManager.Instance.RotateClockwise();
           enemy.spawnAtSpawnPosition();
        }
        
    }

    private void rotateLeft() {
        rotateObject();

        if((transform.rotation.eulerAngles - toRot.eulerAngles).magnitude <= 1f) {
            state = "MOVING";
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            rb.useGravity = true;
            cam.Snap();
           GameManager.Instance.RotateAntiClockwise();
           enemy.spawnAtSpawnPosition();
        }
    }

    private void rotateObject() {
        Quaternion lerpRot = Quaternion.Lerp(fromRot, toRot, timeCount * rotSpeed);

        // Debug.Log(lerpRot.eulerAngles);
        transform.rotation = lerpRot;

        timeCount = timeCount + Time.deltaTime;
    }

    public float distanceBetweenPlayerAndGate() {
        return Vector3.Distance(transform.position, finalGateObject.transform.position);
    }

    void FixedUpdate() {
        if(state == "MOVING") {
            if (grounded) {
                MovePlayer();
            }
        }
        if(isGravity) rb.AddForce(-transform.up * gravityStrength);
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
        if(state == "MOVING") {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensX;
            yRotation += mouseX;
            Vector3 targetRotation = transform.up * yRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), MovementSpeed * Time.deltaTime);
        }
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
