using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{

    private PositionChange PositionScript;
    private ShipController ShipController;
    
    public float accelerationX = 0.0f;
    public float accelerationY = 0.0f;
    public float accelerationZ = 0.0f;

    private float timer = 1.2f;
    private float waitTime = 1.0f;

    private void Start()
    {
        PositionScript = GetComponent<PositionChange>();
        ShipController = GetComponent<ShipController>();
    }
    void Update()
    {
        if (ShipController != null) {
            accelerationX = accelerationX + ShipController.ShipAccelerationX;
            accelerationY = accelerationY + ShipController.ShipAccelerationY;
            accelerationZ += ShipController.ShipAccelerationZ;
        }
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
