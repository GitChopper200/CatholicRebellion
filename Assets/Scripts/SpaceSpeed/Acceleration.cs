using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Acceleration : MonoBehaviour
{

    private PositionChange PositionScript;
    private ShipController ShipController;
    private Gravity gravity1;
    
    public float accelerationX = 0.0f;
    public float accelerationY = 0.0f;
    public float accelerationZ = 0.0f;

    private float timer = 1.2f;
    private float waitTime = 1.0f;

    public bool gotTheInformation; 
    private void Start()
    {
        PositionScript = GetComponent<PositionChange>();
        ShipController = GetComponent<ShipController>();
        gravity1 = GetComponent<Gravity>();
    }
    void Update()
    {
        //This send the acceleration to the PositionChange script, so it can flow around in space.
        //This is also the reciver of everything that have something to do with acceleration. 
        if (ShipController != null) {
            accelerationX += ShipController.ShipAccelerationX;
            accelerationY += ShipController.ShipAccelerationY;
            accelerationZ += ShipController.ShipAccelerationZ;
        }
        
            accelerationX += gravity1.GravitationelAccellerationFinished[0];
            accelerationY += gravity1.GravitationelAccellerationFinished[1];
            accelerationZ += gravity1.GravitationelAccellerationFinished[2];
            gotTheInformation = true;
        
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            accelerationX = 0;
            accelerationY = 0;
            accelerationZ = 0;
            timer = 0;
        }
    }

    public float AccelerationFunction(float speed, float acceleration)
    {
        speed = acceleration + speed;

        return speed;
    }
}
