using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmRightBottomSphereR : MonoBehaviour
{
    public GameObject LeftBottomSphere = null;
    public GameObject TopLeftSphere = null;
    public GameObject TopRightSphere = null;

    Vector3 m_vOriginPos = new Vector3();

    Vector3 m_vConvertPos = new Vector3();

    public static Vector3 m_vPositionR;


    float m_fLerpSpeed = 20f;

    public Vector3 Get_Pos() { return m_vConvertPos; }

    // Update is called once per frame
    void Update()
    {
        m_vOriginPos = transform.position;


        m_vConvertPos = (LeftBottomSphere.GetComponent<SphereSetting>().Get_Pos() - TopLeftSphere.GetComponent<SphereSetting>().Get_Pos()) * 0.85f + TopRightSphere.GetComponent<SphereSetting>().Get_Pos();
        m_vConvertPos = (LeftBottomSphere.GetComponent<SphereSetting>().Get_Pos() - m_vConvertPos) * 0.55f + m_vConvertPos;

        m_vPositionR = m_vConvertPos;
    }

    //ΩÃ±€≈Ê
    private static PalmRightBottomSphereR m_pInstance;
    public static PalmRightBottomSphereR Instance
    {
        get
        {
            if (null == m_pInstance)
            {
                m_pInstance = GameObject.Find("PalmRightBottomSphereR").GetComponent<PalmRightBottomSphereR>();
            }
            return m_pInstance;
        }
    }



}
