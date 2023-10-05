using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCompartment : MonoBehaviour
{
    public GameObject parachuteFirstCompartment;
    private FixedJoint fixedJointParachute;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OpenParachute()
    {
        parachuteFirstCompartment.SetActive(true);
        fixedJointParachute = parachuteFirstCompartment.GetComponent<FixedJoint>();
        fixedJointParachute.connectedBody = gameObject.AddComponent<Rigidbody>();
        transform.SetParent(null);
        parachuteFirstCompartment.transform.SetParent(null);
    }
}
