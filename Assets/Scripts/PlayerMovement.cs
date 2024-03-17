using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float x;
    float y;
    float z;
    public float SensX;
    float yRotation;


    [Header("Movement")]

    public float MovementSpeed;

    public float groundDrag;
    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask WhatIsGround;
    bool grounded;

    public Transform orientation;
    float hInput;
    float vInput;
    Vector3 moveDir;
    Rigidbody rb;

    public SpawnCharacter spawnner;
    public ContainerScript containerScript;
    public GameObject container;
    // public Vector3 gravity;
    public int pos = 0;

    // public GameObject Spawnner;

    public GameInput gameInput;

    private Vector3 spawningPositon = new Vector3(-0.95f, 12.08f, -30.55f);

    public float rotationSpeed = .01f;
    private Vector3 v3ForI = new Vector3(0,0,180);
    private Vector3 v3ForJ = new Vector3(0,0,270);
    private Vector3 v3ForK = new Vector3(0,0,0);
    private Vector3 v3ForL = new Vector3(0,0,90);
    public Vector3 v3Current = new Vector3(0,0,0);
    public Vector3 v3To = new Vector3(0,0,0);

    public Transform cam;
    public Material[] materials; // Array of materials to rotate
    private int currentMaterialIndex = 0; // Index of the currently active material


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(pos);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // materials = new Material[4];

        gameInput.OnIInteractionAction += GameInput_OnIInteractionAction;
        gameInput.OnJInteractionAction += GameInput_OnJInteractionAction;
        //gameInput.OnKInteractionAction += GameInput_OnKInteractionAction;
        gameInput.OnLInteractionAction += GameInput_OnLInteractionAction;
    }

    private void GameInput_OnIInteractionAction(object sender, System.EventArgs e) {
        //I called
        // Debug.Log("I");
        // spawnner.SpawnCharacters(2, spawnner, gameInput);
        //gravity = new Vector3(0, 10f, 0f);
        transform.position = new Vector3(spawningPositon.x, spawningPositon.y, spawningPositon.z);
        // transform.rotation = new Vector3(0f, 0f, 180f);

        // Vector3 eulerAngles = new Vector3(0, 0, 180); 
        // Quaternion rotation = Quaternion.Euler(eulerAngles); 
        // transform.rotation = rotation;
        //transform.position = new Vector3(0f, 3f, 0f);
        RotateTwoSteps();

        v3To = v3ForI;

        //cam.position = new Vector3(cam.position.x, cam.position.y-1.6f,cam.position.z);
        //cam.rotation = Quaternion.Euler(cam.rotation.x, cam.rotation.y, cam.rotation.z - 180);
    }

    private void GameInput_OnJInteractionAction(object sender, System.EventArgs e) {
        //J called
        // Debug.Log("J");
        // gravity = new Vector3(-10f, 1f, 0f);
        transform.position = new Vector3(spawningPositon.x, spawningPositon.y, spawningPositon.z);
        // transform.rotation = new Vector3(0f, 0f, 180f);

        // Vector3 eulerAngles = new Vector3(0, 0, 270); 
        // Quaternion rotation = Quaternion.Euler(eulerAngles); 
        // transform.rotation = rotation;
        //transform.position = new Vector3(0f, 3f, 0f);
        RotateAntiClockwise();

        v3To = v3ForJ;
    }

    // private void GameInput_OnKInteractionAction(object sender, System.EventArgs e) {
    //     //K called
    //     // Debug.Log("K");
    //     // gravity = new Vector3(0f, -10f, 0f);
    //    transform.position = new Vector3(spawningPositon.x, spawningPositon.y, spawningPositon.z);
    //     // transform.rotation = new Vector3(0f, 0f, 180f);

    //     // Vector3 eulerAngles = new Vector3(0, 0, 270); 
    //     // Quaternion rotation = Quaternion.Euler(eulerAngles); 
    //     // transform.rotation = rotation;
    //     pos = 2;
    //     transform.position = new Vector3(0f, 1.5f, 0f);

    //     v3To = v3ForK;
    // }
    private void GameInput_OnLInteractionAction(object sender, System.EventArgs e) {
        //L called
        // Debug.Log("L");
        // gravity = new Vector3(10f, 1f, 0f);
        transform.position = new Vector3(spawningPositon.x, spawningPositon.y, spawningPositon.z);
        // transform.rotation = new Vector3(0f, 0f, 180f);

        // Vector3 eulerAngles = new Vector3(0, 0, 270); 
        // Quaternion rotation = Quaternion.Euler(eulerAngles); 
        // transform.rotation = rotation;
        //transform.position = new Vector3(0f, 3f, 0f);
        RotateClockwise();

        v3To = v3ForL;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Mathf.Abs(v3Current.z - v3To.z) > 0.2f) {
        //     v3Current = Vector3.Slerp(v3Current, v3To, Time.deltaTime * rotationSpeed);

        //     // transform.Rotate(v3Current.x, v3Current.y, v3Current.z, Space.Self);
        //     transform.eulerAngles = v3Current; 
        //     // rb.rotation = transform.rotation;
        //     rb.MoveRotation(transform.rotation);
        // }
        Debug.Log(transform.eulerAngles);
        
        // if(Input.GetKeyDown("i") && pos != 2)
        // {
        //     /*Debug.Log(pos);
        //     spawnner.SpawnCharacters(2);
        //     //orientation = Object_180.GetComponent<Transform>();
        //     Destroy(gameObject);*/
        //     // Instantiate(Object_0, new Vector3(-0.95f, 12.08f, -30.55f), transform.rotation);
        //     // spawnner.SpawnCharacters(2, spawnner);
        //     container.RotateContainer(0);

        // }
        // else if(Input.GetKeyDown("j"))
        // {
        //     // spawnner.SpawnCharacters(3, spawnner);
        // }
        // else if(Input.GetKeyDown("k"))
        // {
        //     // spawnner.SpawnCharacters(0, spawnner);
        // }
        // else if(Input.GetKeyDown("l"))
        // {
        //     // spawnner.SpawnCharacters(1, spawnner);
        // }
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);

        MyInput();
        SpeedControl();
        playerRotation();

        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    void FixedUpdate() {
        MovePlayer();

        //rb.AddForce(gravity.normalized * MovementSpeed * 10f, ForceMode.Force);
    }

    private void MyInput(){
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        Debug.Log("h =" + hInput + "v=" + vInput);
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

    void playerRotation(){
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensX;
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void RotateClockwise()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        ApplyMaterials();
    }

    void RotateAntiClockwise()
    {
        currentMaterialIndex = (currentMaterialIndex - 1 + materials.Length) % materials.Length;
        ApplyMaterials();
    }

    void RotateTwoSteps()
    {
        currentMaterialIndex = (currentMaterialIndex + 2) % materials.Length;
        ApplyMaterials();
    }

    void ApplyMaterials()
    {
        Renderer bottomWall = container.transform.GetChild(0).GetComponent<Renderer>();
        Renderer leftWall = container.transform.GetChild(1).GetComponent<Renderer>();
        Renderer topWall = container.transform.GetChild(2).GetComponent<Renderer>();
        Renderer rightWall = container.transform.GetChild(3).GetComponent<Renderer>();

        bottomWall.material = materials[currentMaterialIndex];
        leftWall.material = materials[(currentMaterialIndex + 1) % materials.Length];
        topWall.material = materials[(currentMaterialIndex + 2) % materials.Length];
        rightWall.material = materials[(currentMaterialIndex + 3) % materials.Length];
    }

}
