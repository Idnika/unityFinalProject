using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineLookAt : MonoBehaviour
{
    public GameObject leftWristPosition = null;
    public GameObject rightWristPosition = null;

    public Vector3 wristVector = new Vector3(0.0f, 0.0f, 0.0f);

    Quaternion tempYangle = Quaternion.identity;
    public GameObject targetSpine = null;

    // Start is called before the first frame update
    void Start()
    {


        targetSpine.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        wristVector.x = (leftWristPosition.transform.position.x + rightWristPosition.transform.position.x) / 2;
        wristVector.y = (leftWristPosition.transform.position.y + rightWristPosition.transform.position.y) / 2;
        wristVector.z = (leftWristPosition.transform.position.z + rightWristPosition.transform.position.z) / 2;

        targetSpine.transform.LookAt(wristVector);
        tempYangle.eulerAngles = targetSpine.transform.eulerAngles;
        Vector3 tempYYangle = new Vector3(transform.rotation.eulerAngles.x, tempYangle.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(tempYYangle);
        // transform.rotation = Quaternion.Euler(tempYangle.eulerAngles.x, 0, 0);
        // transform.rotation = Quaternion.Euler(0, 0, tempYangle.eulerAngles.z);
    }
}
