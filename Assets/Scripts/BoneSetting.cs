using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSetting : MonoBehaviour
{

    public GameObject ForwardSphere = null;
    public GameObject BackSphere = null;

    Vector3 m_vOriginDir = Vector3.forward;
    Vector3 m_vConvertDir = new Vector3();

    float m_fLerpSpeed = 20f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = ForwardSphere.GetComponent<SphereSetting>().Get_Pos();

        m_vOriginDir = (ForwardSphere.GetComponent<SphereSetting>().Get_Pos() - BackSphere.GetComponent<SphereSetting>().Get_Pos()).normalized;

        m_vConvertDir = (m_vOriginDir * (Time.deltaTime * m_fLerpSpeed) + m_vConvertDir * (1 - Time.deltaTime * m_fLerpSpeed)).normalized;

        if(m_vOriginDir == Vector3.zero)
        {
            m_vOriginDir = Vector3.forward;
        }

        transform.localRotation = Quaternion.LookRotation(m_vOriginDir);
    }
}
