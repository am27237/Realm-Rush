using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class Sandbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.IsPlaying(gameObject))
        {
            // Play logic
        }
        else
        {
            // Editor logic
            Debug.Log("C was pressed");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("C was pressed");
        }
    }
}
