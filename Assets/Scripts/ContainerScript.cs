using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateContainer(int x)
    {
        if (x == 0)
        {
            transform.Rotate(0, 0, 180);
        }
    }
}
