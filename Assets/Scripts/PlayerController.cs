using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool isMotor; //is this wheel attached to motor?
    public bool isSteering; // does this wheel apply steer angle?
}

public class PlayerController : MonoBehaviour
{

    public List<AxleInfo> axleInfos; //the information about each individual axle
    public float maxMotorTorque; // maximum torque  the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] private float speed;
    [SerializeField] private float rpm;



    private Rigidbody playerRb;
    public ParticleSystem crashParticle;
    public ParticleSystem finalCrashParticle;
    public Vector3 COM;
    public GameObject cargo;
    private int cargoCount;
    private GameManager gameManager;





    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = COM;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


    }

    // find the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        //speedometerText.SetText("Speed: " + speed + " kph");

        rpm = (speed % 30) * 40;
        //rpmText.SetText("RPM: " + rpm);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.isSteering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.isMotor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }


            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // When we hit other vehicle - player lose cargo
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            gameManager.CargoCount();

        }
        if (collision.gameObject.CompareTag("Dummy"))
        {
            Rigidbody dummyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position + transform.position).normalized;// + (Vector3.up * 300f); ;

            dummyRigidbody.AddForce(awayFromPlayer * 500f, ForceMode.Impulse);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.LevelPassed();
        }
    }
    public void RegularCrush()
    {
        crashParticle.Play();
    }
    public void FinalCrush()
    {
        finalCrashParticle.Play();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddRelativeForce(new Vector3(0, 1, 1) * 10000f, ForceMode.Impulse);
            Debug.Log("Jump");
        }
    }

}
