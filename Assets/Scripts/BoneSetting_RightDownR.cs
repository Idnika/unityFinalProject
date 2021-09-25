using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSetting_RightDownR : MonoBehaviour
{

    public GameObject ForwardSphere = null;
    public GameObject BackSphere = null;

    Vector3 m_vOriginDir = new Vector3();
    Vector3 m_vConvertDir = new Vector3();

    float m_fLerpSpeed = 20f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = PalmRightBottomSphereR.Instance.Get_Pos();

        m_vOriginDir = (PalmRightBottomSphereR.Instance.Get_Pos() - BackSphere.GetComponent<SphereSetting>().Get_Pos()).normalized;

        m_vConvertDir = (m_vOriginDir * (Time.deltaTime * m_fLerpSpeed) + m_vConvertDir * (1 - Time.deltaTime * m_fLerpSpeed)).normalized;

        transform.localRotation = Quaternion.LookRotation(m_vOriginDir);
    }
}
