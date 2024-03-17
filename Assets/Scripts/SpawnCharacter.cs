using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public GameObject Spawnner;
    public float spawnRate = 1;
    public float timer = 0;
    public GameObject Object_0;
    public GameObject Object_90;
    public GameObject Object_180;
    public GameObject Object_270;

    // Update is called once per frame

    public void SpawnCharacters(int pos, SpawnCharacter spawnner, GameInput gameInput)
    {
        if(pos == 0) {
            Instantiate(Object_0, new Vector3(-0.95f, 12.08f, -30.55f), transform.rotation);
            Object_0.GetComponent<PlayerMovement>().spawnner = spawnner;
            Object_0.GetComponent<PlayerMovement>().gameInput = gameInput;
        } else if(pos == 1) {
            Instantiate(Object_90, new Vector3(-0.95f, 12.08f, -30.5f), transform.rotation);
            Object_90.GetComponent<PlayerMovement>().spawnner = spawnner;
            Object_0.GetComponent<PlayerMovement>().gameInput = gameInput;
        } else if(pos == 2) {
            Instantiate(Object_180, new Vector3(-0.95f, 12.08f, -30.55f), transform.rotation);
            Object_180.GetComponent<PlayerMovement>().spawnner = spawnner;
            Object_0.GetComponent<PlayerMovement>().gameInput = gameInput;
        } else if(pos == 3) {
            Instantiate(Object_270, new Vector3(-0.95f, 12.08f, -30.55f), transform.rotation);
            Object_270.GetComponent<PlayerMovement>().spawnner = spawnner;
            Object_0.GetComponent<PlayerMovement>().gameInput = gameInput;
        }
    }
}
