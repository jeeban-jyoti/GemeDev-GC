using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamMovement : MonoBehaviour
{
    public Transform posTarget;
    public Transform lookTarget;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        Vector3 targetPosition = posTarget.position;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.rotation = Quaternion.LookRotation(lookTarget.position - transform.position, lookTarget.transform.up);
    }

    public void Snap() {
        transform.position = posTarget.position;
        transform.rotation = Quaternion.LookRotation(lookTarget.position - transform.position, lookTarget.transform.up);
    }
}
