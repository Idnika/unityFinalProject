using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTopSphere02R : MonoBehaviour
{
    Vector3 m_vOriginPos = new Vector3();

    Vector3 m_vConvertPos = new Vector3();

    float m_fLerpSpeed = 20f;

    public Vector3 Get_Pos() { return m_vConvertPos; }

    // Update is called once per frame
    void Update()
    {
        m_vOriginPos = transform.position;

        m_vConvertPos = m_vOriginPos * (Time.deltaTime * m_fLerpSpeed) + m_vConvertPos * (1 - Time.deltaTime * m_fLerpSpeed);
    }

    //�̱���
    private static PalmTopSphere02R m_pInstance;
    public static PalmTopSphere02R Instance
    {
        get
        {
            if (null == m_pInstance)
            {
                m_pInstance = GameObject.Find("PalmTopSphere02R").GetComponent<PalmTopSphere02R>();
            }
            return m_pInstance;
        }
    }



}
