using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEOVERSCRIPT : MonoBehaviour
{
    public void Quit(){
        Debug.Log("ended");
        Application.Quit();
    }
}
