using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger_Colliders : MonoBehaviour
{
    public GameObject objCollider01 = null;
    public GameObject objCollider02 = null;
    public GameObject objCollider03 = null;
    public GameObject objCollider04 = null;
    public GameObject objCollider05 = null;
    public GameObject objCollider06 = null;
    public GameObject objCollider07 = null;
    public GameObject objCollider08 = null;
    public GameObject objCollider09 = null;
    public GameObject objCollider10 = null;

    private static Vector3[] m_vPos;
    public static Vector3[] Get_Pos() { return m_vPos; }
    
    private static float m_fRadius = 0.025f;


    public static float Culc_Collider(Vector3 vWhiteKey)
    {

        float fMax = 0f;
        float fTemp = 0f;

        for (int i = 0; i < 10; ++i)
        {
            if(!(Mathf.Abs(vWhiteKey.x-m_vPos[i].x) <= m_fRadius * 1.5f
                && Mathf.Abs(vWhiteKey.z-m_vPos[i].z) <= m_fRadius * 5f))
                continue;

            fTemp = m_fRadius - (m_vPos[i].y - vWhiteKey.y);

            if (fTemp > 0f && fMax < fTemp)
            {
                fMax = fTemp;
            }
        }

        return fMax;
    }

    void Start()
    {
        m_vPos = new Vector3[10];

        for (int i = 0; i < 10; ++i)
        {
            m_vPos[i] = Vector3.zero;
        }
    }

    void Update()
    {

        for (int i = 0; i < 10; ++i)
        {
            switch(i)
            {
                case 0:
                    m_vPos[i] = objCollider01.transform.position;
                    break;
                case 1:
                    m_vPos[i] = objCollider02.transform.position;
                    break;
                case 2:
                    m_vPos[i] = objCollider03.transform.position;
                    break;
                case 3:
                    m_vPos[i] = objCollider04.transform.position;
                    break;
                case 4:
                    m_vPos[i] = objCollider05.transform.position;
                    break;
                case 5:
                    m_vPos[i] = objCollider06.transform.position;
                    break;
                case 6:
                    m_vPos[i] = objCollider07.transform.position;
                    break;
                case 7:
                    m_vPos[i] = objCollider08.transform.position;
                    break;
                case 8:
                    m_vPos[i] = objCollider09.transform.position;
                    break;
                case 9:
                    m_vPos[i] = objCollider10.transform.position;
                    break;
                default:
                    break;
            }
        }
    }
}
