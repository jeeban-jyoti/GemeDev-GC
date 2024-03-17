using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentTimeDisplay : MonoBehaviour
{
    private FinalGate finalGateObject;
    private string finalGateTag = "FinalGate";
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag(finalGateTag);
        finalGateObject = gameObject.GetComponent<FinalGate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(finalGateObject.hasGateBeenOpenend()) {
            countdownText.text = "Gate Openend!";
        } else {
            int timeInInt = Mathf.FloorToInt(finalGateObject.getCurrentTime());
            countdownText.text = "Time Elapsed: " + timeInInt.ToString();
        }
        // Debug.Log(finalGateObject.getCurrentTime());
    }
}
