using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScenes : MonoBehaviour
{
    public Transform playerSpawn;
    public Transform enemySpawn;
    public GameObject player;
    public GameObject enemy;

    public GameObject level;
    public GameObject levelUI;
    public GameObject menuUi;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartGame() {
        levelUI.SetActive(true);
        level.SetActive(true);
        menuUi.SetActive(false);
        gameOver.SetActive(false); 
        player.SetActive(true);

        player.transform.position = playerSpawn.position;
        enemy.transform.position = enemySpawn.position;
    }

    public void onGameOver() {
        levelUI.SetActive(false);
        level.SetActive(false);
        menuUi.SetActive(false);
        gameOver.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
