using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbDownTest : MonoBehaviour
{
    public GameObject isKeyDown = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = isKeyDown.transform.position;
        }
    }
}
