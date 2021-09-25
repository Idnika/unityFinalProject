using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveTest : MonoBehaviour
{
    static int m_iNumber = 0;
    static int m_iNumberMax = 10;

    static int m_iFrameCur = 0;
    static int m_iFrameMax = 60;
    static int m_iAniSphereMaxR = 21;

    public static Vector3[] m_arrPositionR = null;

    // Start is called before the first frame update
    void Start()
    {
        SphereSetting.Initialize();
        m_arrPositionR = new Vector3[m_iAniSphereMaxR * m_iFrameMax];
        Debug.Log("help");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_iNumber >= m_iNumberMax)
            return;

        for (int i = 0; i < m_iAniSphereMaxR; ++i)
        {
            if(i < 20)
            {
                m_arrPositionR[m_iFrameCur * m_iAniSphereMaxR + i] = SphereSetting.m_arrPositionR[i];
            }
            else
            {
                m_arrPositionR[m_iFrameCur * m_iAniSphereMaxR + i] = PalmRightBottomSphereR.m_vPositionR;
            }

        }


        ++m_iFrameCur;
        if(m_iFrameCur >= m_iFrameMax)
        {
            ++m_iNumber;
            m_iFrameCur = 0;
            File.Create("Assets/Resources/NewFile" + m_iNumber + ".txt");

            for (int i = 0; i < m_iAniSphereMaxR; ++i)
            {
                //m_arrPositionR[m_iFrameCur * m_iAniSphereMaxR + i]
            }
        }




    }
}
