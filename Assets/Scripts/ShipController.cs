using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private PositionChange PositionChange;

    public float PositionAccelerationX;
    public float PositionAccelerationY;
    public float PositionAccelerationZ;

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
        }
    }
}
