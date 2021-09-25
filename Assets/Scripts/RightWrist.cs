using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWrist : MonoBehaviour
{

    public GameObject isKeyDown = null;

    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("I got update");
            transform.position = isKeyDown.transform.position;
            transform.position += new Vector3(0.4f, 0.3f, -0.45f);
        }
    }
}
