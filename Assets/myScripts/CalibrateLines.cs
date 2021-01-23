using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateLines : MonoBehaviour
{

    public GameObject m_HandJoint;
    public GameObject m_ConfigPoint;


    void Start()
    {
   
    }

    void Update()
    {
        Calibrate();    //\todo call in GameManager
    }

    void Calibrate()
    {
        //calibrate image position for 3s //\todo 
        if (Time.time < 10.0)
        {
            m_ConfigPoint.transform.position = new Vector3(m_HandJoint.transform.position.x, m_ConfigPoint.transform.position.y, m_HandJoint.transform.position.z);
        }
    }
}
