using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceDisplay : MonoBehaviour
{
    private FinalGate finalGateObject;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] Text distanceText;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerMovement.distanceBetweenPlayerAndGate());
        int distanceInInt = Mathf.FloorToInt(playerMovement.distanceBetweenPlayerAndGate());
        distanceText.text = "Distance: " + distanceInInt.ToString();
    }
}
