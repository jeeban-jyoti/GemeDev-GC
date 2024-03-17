using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private GameInput gameInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private GameObject container;
    private bool hasGateOpened;

    public ManageScenes sm;

    [Header("ContainerRotation")]
    [SerializeField] private Material[] materials; // Array of materials to rotate
    private int currentMaterialIndex = 0; // Index of the currently active material

    // private enum State{
    //     GameStart,
    //     GamePlaying,
    //     GameOver,
    // }

    // private State state;
    
    public static GameManager Instance {
        get {
            if (instance == null) {
                Debug.LogError("Game Manager is null");
            }

            return instance;
        }
    }

    private void Awake() {
        instance = this;
        // GameStartSceneLoad();
    }

    private void Start() {

        gameInput.OnIInteractionAction += GameInput_OnIInteractionAction;
        gameInput.OnJInteractionAction += GameInput_OnJInteractionAction;
        //gameInput.OnKInteractionAction += GameInput_OnKInteractionAction;
        gameInput.OnLInteractionAction += GameInput_OnLInteractionAction;

        hasGateOpened = true;
    }

    private void GameInput_OnIInteractionAction(object sender, System.EventArgs e) {
        //Upper maze activate

        // Ask the player script to spawn the player at spawn position
        playerMovement.spawnAtSpawnPosition();

        spawnEnemiesAtSpawnPosition();
        RotateTwoSteps();
    }

    private void GameInput_OnJInteractionAction(object sender, System.EventArgs e) {
        //Left maze activate

        // Ask the player script to spawn the player at spawn position
        playerMovement.spawnAtSpawnPosition();

        spawnEnemiesAtSpawnPosition();

        RotateAntiClockwise();
    }

    private void GameInput_OnLInteractionAction(object sender, System.EventArgs e) {
        //Right maze activate

        // Ask the player script to spawn the player at spawn position
        playerMovement.spawnAtSpawnPosition();
        spawnEnemiesAtSpawnPosition();
        RotateClockwise();
    }

    private void spawnEnemiesAtSpawnPosition() {
        foreach (Enemy enemy in enemyList) {
            enemy.spawnAtSpawnPosition();
        }
    }

    public void RotateClockwise()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        ApplyMaterials();
    }

    public void RotateAntiClockwise()
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

    public void gateAreOpened() {
        hasGateOpened = true;
    }

    public void hasPlayerReached(bool playerNearGate) {
        if (playerNearGate) {
            if (hasGateOpened) {
                if (currentMaterialIndex == 0) {
                    Debug.LogError("Game Won");
                    sm.onGameOver();
                }
            }
        }
    }

    public bool isGroundFloor() {
        return (currentMaterialIndex == 0);
    }

    public void GameStartSceneLoad()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void GamePlaySceneLoad()
    {
        SceneManager.LoadScene("Level_Maze_1");
    }
    public void GameOverSceneLoad()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
