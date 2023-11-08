using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private PositionChange PositionChange;

    private float PositionAccelerationX;
    private float PositionAccelerationY;
    private float PositionAccelerationZ;

    private float timer = 10.25f;
    private float waitTime = 1.0f;
    private void Start()
    {
        PositionChange = GetComponent<PositionChange>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            PositionAccelerationX = PositionChange.accelerationX;
            PositionAccelerationY = PositionChange.accelerationY;
            PositionAccelerationZ = PositionChange.accelerationZ;

            Debug.Log(PositionAccelerationX + "" + PositionAccelerationY + "" + PositionAccelerationZ);

            timer = 0;
        }
    }
}
