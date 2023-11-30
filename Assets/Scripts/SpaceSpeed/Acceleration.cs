using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    private ShipController ShipController;
    private Gravity gravity1;

    public float accelerationX = 0.0f;
    public float accelerationY = 0.0f;
    public float accelerationZ = 0.0f;

    public float falseAccelerationX = 0.0f;
    public float falseAccelerationY = 0.0f;
    public float falseAccelerationZ = 0.0f;

    public bool CalculateOn = true; 
    private void Start()
    {
        ShipController = GetComponent<ShipController>();
        gravity1 = GetComponent<Gravity>();
    }
    void Update()
    {
        //This send the acceleration to the PositionChange script, so it can flow around in space.
        //This is also the reciver of everything that have something to do with acceleration. 
        
            if (ShipController != null)
            {
                accelerationX = ShipController.ShipAccelerationX + gravity1.GravitationelAccellerationFinished[0];
                accelerationY = ShipController.ShipAccelerationY + gravity1.GravitationelAccellerationFinished[1];
                accelerationZ = ShipController.ShipAccelerationZ + gravity1.GravitationelAccellerationFinished[2];
                CalculateOn = gravity1.newInformation;
            }
            else
            {
                accelerationX = gravity1.GravitationelAccellerationFinished[0];
                accelerationY = gravity1.GravitationelAccellerationFinished[1];
                accelerationZ = gravity1.GravitationelAccellerationFinished[2];

            }
        
    }

    public float AccelerationFunction(float speed, float acceleration)
    {
        speed = acceleration + speed;

        return speed;
    }
}
