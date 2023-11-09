using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{

    private PositionChange PositionScript;
    
    public float accelerationX = 0.0f;
    public float accelerationY = 0.0f;
    public float accelerationZ = 0.0f;

    private float referenceSpeedX = 0.0f;
    private float referenceSpeedY = 0.0f;
    private float referenceSpeedZ = 0.0f;

    private void Start()
    {
        PositionScript = GetComponent<PositionChange>();
    }
    void Update()
    {
    }

    public float AccelerationFunction(float speed, float acceleration)
    {
        speed = acceleration + speed;

        return speed;
    }
}
