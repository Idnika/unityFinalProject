using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Map : MonoBehaviour
{
    Material m_shaderMaterial = null;

    float m_fTimeDeltaF01 = 0;
    float m_fTimeDeltaB01 = 0;

    float m_fTimeDeltaF02 = 0;
    float m_fTimeDeltaB02 = 0;

    float m_fTimeDeltaF03 = 0;
    float m_fTimeDeltaB03 = 0;

    void Start()
    {
        m_shaderMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_fTimeDeltaF01 = 0;
            m_fTimeDeltaB01 = -20;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_fTimeDeltaF02 = 0;
            m_fTimeDeltaB02 = -20;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_fTimeDeltaF03 = 0;
            m_fTimeDeltaB03 = -20;
        }

        m_fTimeDeltaF01 += Time.deltaTime * 200f;
        m_fTimeDeltaB01 += Time.deltaTime * 200f;

        m_fTimeDeltaF02 += Time.deltaTime * 200f;
        m_fTimeDeltaB02 += Time.deltaTime * 200f;

        m_fTimeDeltaF03 += Time.deltaTime * 200f;
        m_fTimeDeltaB03 += Time.deltaTime * 200f;

        m_shaderMaterial.SetFloat("_TimeDeltaF01", m_fTimeDeltaF01);
        m_shaderMaterial.SetFloat("_TimeDeltaB01", m_fTimeDeltaB01);
        m_shaderMaterial.SetVector("_StartPos", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0f));

        m_shaderMaterial.SetFloat("_TimeDeltaF02", m_fTimeDeltaF02);
        m_shaderMaterial.SetFloat("_TimeDeltaB02", m_fTimeDeltaB02);
        // m_shaderMaterial.SetVector("_StartPos", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0f));

        m_shaderMaterial.SetFloat("_TimeDeltaF03", m_fTimeDeltaF03);
        m_shaderMaterial.SetFloat("_TimeDeltaB03", m_fTimeDeltaB03);
        // m_shaderMaterial.SetVector("_StartPos", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0f));

    }
}
