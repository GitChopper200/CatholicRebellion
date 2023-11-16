using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
    private PositionChange PositionChange;

    public float ShipAccelerationX;
    public float ShipAccelerationY;
    public float ShipAccelerationZ;

    private float timer = 10.25f;
    private float waitTime = 1.0f;

    private float powerFromBack = 0.000001f;
    private void Start()
    {
        PositionChange = GetComponent<PositionChange>();

        //waitTime = PositionChange.waitTime;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            ShipAccelerationZ = ShipAccelerationZ + powerFromBack;
        }
        if (Input.GetKey(KeyCode.Z)) {
            ShipAccelerationZ = ShipAccelerationZ - powerFromBack;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            ShipAccelerationY = ShipAccelerationY + powerFromBack;
        }
        if( Input.GetKey(KeyCode.DownArrow))
        {
            ShipAccelerationY = ShipAccelerationY - powerFromBack;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ShipAccelerationX = ShipAccelerationX + powerFromBack;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ShipAccelerationX = ShipAccelerationX - powerFromBack;
        }
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            ShipAccelerationX = 0;
            ShipAccelerationY = 0;
            ShipAccelerationZ = 0;

            timer = 0;
        }
    }
}