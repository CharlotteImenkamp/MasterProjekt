using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateLines : MonoBehaviour
{

    public GameObject m_HandJoint;
    public GameObject m_ConfigPoint;


    void Start()
    {
        //var hand = Hands.Get(Chirality.Right);
        //Vector3 indexPosition; 

    }

    void Update()
    {
        Calibrate();    //\todo call in GameManager
    }

    void Calibrate()
    {
        //calibrate image position for 3s //\todo 

         
        if (Time.time < 30.0)
        {
            //indexPosition = hand.Fingers[1].TipPosition.ToVector3();
            //m_ConfigPoint.transform.position = new Vector3(m_ConfigPoint.transform.position.x, m_ConfigPoint.transform.position.y, indexPosition.transform.position.z);
        }
    }
}
