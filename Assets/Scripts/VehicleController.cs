using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AIAxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool isMotor; //is this wheel attached to motor?
    public bool isSteering; // does this wheel apply steer angle?
}

public class VehicleController : MonoBehaviour
{

    public List<AIAxleInfo> axleInfos; //the information about each individual axle
    public float maxMotorTorque; // maximum torque  the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float goingForward = 1;  // 1 make gas on vehicle, 0 no gas
    private float turnCar;

    private Rigidbody vehicleRb;
    public Vector3 COM;


    // Start is called before the first frame update
    private void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        vehicleRb.centerOfMass = COM;

        // Gives the car a boost when spawned
        vehicleRb.AddRelativeForce(Vector3.forward * 30000, ForceMode.Impulse);



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
        float motor = maxMotorTorque * goingForward;
        float steering = maxSteeringAngle * turnCar;


        foreach (AIAxleInfo axleInfo in axleInfos)
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

        // Now its time to Raycast
        //Ray forwardRay = new Ray(transform.position + rayOffset, transform.forward);
        //Debug.DrawRay(transform.position + rayOffset, transform.forward * distance, Color.yellow);
        //RaycastHit hit;
        //if (Physics.Raycast(forwardRay, distance))
        //{
        //vehicleRb.AddRelativeForce(-Vector3.forward * 50, ForceMode.Impulse);
        //     goingForward = -1;
        //}
        //else { goingForward = 1; }



    }

}
