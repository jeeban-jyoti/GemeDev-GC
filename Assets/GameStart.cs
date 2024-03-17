using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private static string NameFromIndex(int BuildIndex) {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
//     private GameManager manager;
    // Start is called before the first frame update
    public void StartGame(){
        // manager.GamePlaySceneLoad();
        Debug.Log(NameFromIndex(0));
        Debug.Log(NameFromIndex(1));
        Debug.Log(NameFromIndex(2));

        SceneManager.LoadScene("Level_Maze_1");
    }
}
