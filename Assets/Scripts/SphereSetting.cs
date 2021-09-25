using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSetting : MonoBehaviour
{
    Vector3 m_vOriginPos = new Vector3();
    Vector3 m_vConvertPos = new Vector3();

    float m_fLerpSpeed = 20f;

    public Vector3 Get_Pos() { return m_vConvertPos; }

    public static Vector3[] m_arrPositionR;

    static int m_iSphereNum = 0;
    int m_iSphereID = 0;

    public static void Initialize()
    {
        m_arrPositionR = new Vector3[20];
    }

    void Start()
    {
        m_iSphereID = m_iSphereNum;
        ++m_iSphereNum;
    }

    // Update is called once per frame
    void Update()
    {
        m_vOriginPos = transform.position;

        m_vConvertPos = m_vOriginPos * (Time.deltaTime * m_fLerpSpeed) + m_vConvertPos * (1 - Time.deltaTime * m_fLerpSpeed);

        m_arrPositionR[m_iSphereID] = m_vConvertPos;
    }
}
