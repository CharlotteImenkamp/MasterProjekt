using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalibrateLines : MonoBehaviour
{

    public Vector3 m_HandPos;
    public GameObject m_ConfigPoint;

    void Start()
    {
        m_HandPos = Vector3.zero; 
    }

    void Update()
    {
        m_HandPos = GameManager.Instance.idxFingerRightPos; 
        if(m_HandPos.z != 0)
        {
            Calibrate();  
        }
    }

    void Calibrate()
    {
        //calibrate image position for 3s //\todo 
        if (Time.time < 30.0)
        {
            m_ConfigPoint.transform.position = new Vector3(m_ConfigPoint.transform.position.x, m_ConfigPoint.transform.position.y, m_HandPos.z);
        }
    }
}
