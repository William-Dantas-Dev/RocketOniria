using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [Header("References")]
    public RocketCameraController cameraController;
    public CanvasController canvasController;
    public GameObject secondCamera;


    [Header("Propellant Effect")]
    [SerializeField] private ParticleSystem propellantEffect;

    [Header("Rocket Variables")]
    public float thrustForce = 10.0f;
    public float fuelDuration = 5.0f;
    public float maxVelocity = 10.0f;
    public float maxHeight = 0.0f;
    public float rotateSpeed = 50f;
    private bool rocketLaunch;


    private Rigidbody rb;
    private float fuelTimer = 0.0f;

    [Header("Compartments")]
    public FirstCompartment firstCompartmentController;
    public NoseComponent noseComponentController;
    private bool detachCompartment;


    private bool startSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fuelTimer = fuelDuration;
    }

    private void Update()
    {
        if (!rocketLaunch)
        {
            RotateRocket();
            return;
        }
        float currentHeight = transform.position.y;
        if (currentHeight > maxHeight)
        {
            maxHeight = currentHeight;
            canvasController.maxHeightText((int)maxHeight);
        }
        if (transform.position.y < maxHeight / 2)
        {
            noseComponentController.OpenParachute();
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (!rocketLaunch) return;
        if (fuelTimer > 0)
        {
            canvasController.ImageFilled(fuelTimer, fuelDuration);
            if (!startSound)
            {
                startSound = true;
                AudioController.instance.StartRocketSound();
                propellantEffect.Play();
            }
            rb.AddForce(transform.up * thrustForce * Time.fixedDeltaTime);
            fuelTimer -= Time.fixedDeltaTime;
        }
        else
        {
            if (startSound)
            {
                startSound = false;
                AudioController.instance.StopRocketSound();
                propellantEffect.Stop();
                cameraController.ChangeCameraRect();
                secondCamera.SetActive(true);
            }
            if (!detachCompartment)
            {
                firstCompartmentController.OpenParachute();
                detachCompartment = true;
            }
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);

    }

    public void RocketLauncher()
    {
        rocketLaunch = true;
        rb.isKinematic = false;
    }

    private void RotateRocket()
    {
        float horizontal = Input.GetAxis("Horizontal") * -1;
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0 || vertical != 0)
        { 
            transform.Rotate(vertical * rotateSpeed * Time.deltaTime, 0f, horizontal * rotateSpeed * Time.deltaTime);
            Vector3 actualRotate = transform.eulerAngles;

            if (transform.eulerAngles.x > 30 || transform.eulerAngles.x < 330)
            {
                if (transform.eulerAngles.x > 0f && transform.eulerAngles.x < 50f)
                {
                    actualRotate.x = Mathf.Clamp(actualRotate.x, 0f, 30f);
                }
                else
                {
                    actualRotate.x = Mathf.Clamp(actualRotate.x, 330f, 360f);
                }
            }

            if (transform.eulerAngles.z > 30 || transform.eulerAngles.z < 330)
            {
                if (transform.eulerAngles.z > 0f && transform.eulerAngles.z < 50f)
                {
                    actualRotate.z = Mathf.Clamp(actualRotate.z, 0f, 30f);
                }
                else
                {
                    actualRotate.z = Mathf.Clamp(actualRotate.z, 330f, 360f);
                }
            }

            transform.eulerAngles = actualRotate;
        }
    }
}

