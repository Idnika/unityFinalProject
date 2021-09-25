using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCollider : MonoBehaviour
{
    Vector3 m_vOriginPos = Vector3.zero;
    bool m_bPress = false;

    float m_fTimeCur = 0f;
    float m_fTimeMax = 1f;

    void Start()
    {
        m_vOriginPos = transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.parent.transform.position += new Vector3(0, Time.deltaTime * 0.5f, 0);

        float fResult = Finger_Colliders.Culc_Collider(transform.position);

        transform.parent.transform.position -= new Vector3(0, fResult, 0);

        if(transform.parent.transform.localPosition.y > 0f)
            transform.parent.transform.localPosition = new Vector3(0, 0, 0);
        if (transform.parent.transform.localPosition.y < -0.08f)
            transform.parent.transform.localPosition = new Vector3(0, -0.08f, 0);
    }
}
