using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseComponent : MonoBehaviour
{
    [Header("References")]
    public CanvasController canvasController;

    public GameObject parachuteNoseComponent;
    private FixedJoint fixedJointParachute;
    public Rigidbody rbParachute;
    public float parachuteDrag;
    private bool activeParachute;
    void Start()
    {

    }


    void Update()
    {
        if(activeParachute)
        {
            rbParachute.drag = Mathf.Lerp(rbParachute.drag, parachuteDrag, Time.deltaTime);
        }
    }

    public void OpenParachute()
    {
        parachuteNoseComponent.SetActive(true);
        fixedJointParachute = parachuteNoseComponent.GetComponent<FixedJoint>();
        fixedJointParachute.connectedBody = gameObject.AddComponent<Rigidbody>();
        transform.SetParent(null);
        parachuteNoseComponent.transform.SetParent(null);
        activeParachute = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canvasController.ActiveRestartButton();
        }
    }
}
