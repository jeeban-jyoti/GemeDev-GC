using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent enemy;
    [SerializeField] private float destroyRange = 1.5f;
    [SerializeField] private float detectionRange = 8f;

    [SerializeField] private Vector3 spawningPositon;

    public ManageScenes sm;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination = playerTransform.position;

        // Check if the player is within detectionRange
        if (Vector3.Distance(transform.position, playerTransform.position) <= detectionRange)
        {
            RaycastHit hit;
            Vector3 direction = playerTransform.position - transform.position;

            // Check if there are no obstacles between enemy and player
            if (Physics.Raycast(transform.position, direction, out hit, detectionRange))
            {
                Debug.Log("Player Inside detection range");
                // if (hit.collider.CompareTag("Player"))
                if(hit.collider.GetComponent<PlayerMovement>() != null);
                {
                    // Player is within detection range and is not blocked by obstacles
                    // Check if player is within destroy range
                    if (Vector3.Distance(transform.position, playerTransform.position) <= destroyRange)
                    {
                        Debug.LogError("Game Over");
                        DestroyPlayer();
                    }
                }
            }
        }
    }

    void DestroyPlayer()
    {
        // Assuming the player has a "Player" tag, you can replace it with the actual tag of your player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            player.SetActive(false);
            sm.onGameOver();
        }
    }

    public void spawnAtSpawnPosition() {
        transform.position = new Vector3(spawningPositon.x, spawningPositon.y, spawningPositon.z);
    }
}
