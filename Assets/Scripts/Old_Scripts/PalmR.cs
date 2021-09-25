using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmR : MonoBehaviour
{
    Vector3 m_vPos = new Vector3();

    public Vector3 Get_Pos() { return m_vPos; }

    // Update is called once per frame
    void Update()
    {
        m_vPos = transform.position;
    }

    //ΩÃ±€≈Ê
    private static PalmR m_pInstance = null;
    public static PalmR Instance
    {
        get
        {
            if (null == m_pInstance)
            {
                m_pInstance = GameObject.Find("PalmR").GetComponent<PalmR>();
            }
            return m_pInstance;
        }
    }
}
