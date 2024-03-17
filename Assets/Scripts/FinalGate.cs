using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGate : MonoBehaviour {

    private float currentTime;
    [SerializeField] private float gateOpenTime = 120f;
    
    private bool hasGateOpened;

    [SerializeField] private Material groundFloorMaterial;
    [SerializeField] private Material otherFloorMaterial;


    // Start is called before the first frame update
    void Start() {
        currentTime = 0f;
        hasGateOpened = false;
    }

    // Update is called once per frame
    void Update() {
        if (!hasGateOpened) {
            if (currentTime >= gateOpenTime) {
                // gate is open according to time
                hasGateOpened = true;
                GameManager.Instance.gateAreOpened();
            } else {
                currentTime += Time.deltaTime;
            }
        }

        if (GameManager.Instance.isGroundFloor()) {
            setMaterial(groundFloorMaterial);
        } else {
            setMaterial(otherFloorMaterial);
        }
    }

    private void setMaterial(Material material) {
        GetComponent<Renderer>().material = material;
    }

    public float getCurrentTime() {
        return currentTime;
    }

    public bool hasGateBeenOpenend() {
        return hasGateOpened;
    }
}
