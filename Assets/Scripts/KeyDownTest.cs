using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDownTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("I Pressed A");
            transform.position -= new Vector3(0, 0.08f, 0);
        }
    }
}
