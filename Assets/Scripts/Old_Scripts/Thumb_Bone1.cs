using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thumb_Bone1 : MonoBehaviour
{
    Vector3 m_vPos = new Vector3();

    public Vector3 Get_Pos() { return m_vPos; }

    // Update is called once per frame
    void Update()
    {
        m_vPos = transform.position;
    }

    //ΩÃ±€≈Ê
    private static Thumb_Bone1 m_pInstance;
    public static Thumb_Bone1 Instance
    {
        get
        {
            if (null == m_pInstance)
            {
                m_pInstance = GameObject.Find("ThumbBone1R").GetComponent<Thumb_Bone1>();
            }
            return m_pInstance;
        }
    }



}
