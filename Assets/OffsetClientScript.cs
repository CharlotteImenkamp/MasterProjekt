using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;


public class OffsetClientScript : MonoBehaviour
{
    public HandModelManager m_handModelManager;

    // Start is called before the first frame update
    void Start()
    {
    // HANDS
        m_handModelManager = this.gameObject.GetComponent<HandModelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
