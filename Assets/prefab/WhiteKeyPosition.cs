using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKeyPosition : MonoBehaviour
{
    Vector3 originPos = Vector3.zero;
    Vector3 curPos = Vector3.zero;
    Vector3 downDistance = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
