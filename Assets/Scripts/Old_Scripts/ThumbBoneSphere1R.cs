using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbBoneSphere1R : MonoBehaviour
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

    //ΩÃ±€≈Ê
    private static ThumbBoneSphere1R m_pInstance;
    public static ThumbBoneSphere1R Instance
    {
        get
        {
            if (null == m_pInstance)
            {
                m_pInstance = GameObject.Find("ThumbBoneSphere1R").GetComponent<ThumbBoneSphere1R>();
            }
            return m_pInstance;
        }
    }



}
