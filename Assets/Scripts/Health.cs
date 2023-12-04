using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float BodyHealth = 1f;

    public float BodyHit(float health, float SpeedX, float SpeedY, float SpeedZ, float OtherSpeedX, float OtherSpeedY, float OtherSpeedZ, float otherMass)
    {
        SpeedX = Mathf.Abs(SpeedX);
        SpeedY = Mathf.Abs(SpeedY);
        SpeedZ = Mathf.Abs(SpeedZ);
        OtherSpeedX = Mathf.Abs(OtherSpeedX);
        OtherSpeedY = Mathf.Abs(OtherSpeedY);
        OtherSpeedZ = Mathf.Abs(OtherSpeedZ);

        float totalSpeed = (SpeedX+SpeedY+SpeedZ+OtherSpeedX+OtherSpeedY+OtherSpeedZ) * otherMass;
        Debug.Log(totalSpeed);
        health = health - totalSpeed;
        return health;
    }
}
