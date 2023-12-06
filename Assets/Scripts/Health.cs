using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float BodyHealth = 1f;

    public float BodyHit(float health, float SpeedX, float SpeedY, float SpeedZ, float OtherSpeedX, float OtherSpeedY, float OtherSpeedZ, float otherMass)
    {
        

        float TotalSpeed = SpeedX + SpeedY + SpeedZ;
        float TotalOtherSpeed = OtherSpeedX + OtherSpeedY + OtherSpeedZ;

        float TotalSpeedX = SpeedX + OtherSpeedX;
        float TotalSpeedY = SpeedY + OtherSpeedY;
        float TotalSpeedZ = OtherSpeedZ + OtherSpeedZ;

        float TotalSpeedTotal = (TotalSpeedX + TotalSpeedY + TotalSpeedZ) * otherMass;

        TotalSpeedTotal = Mathf.Abs(TotalSpeedTotal);
        health = health - TotalSpeedTotal * 0.01f;
        CheckHealth(health);
        Debug.Log(health);
        return health;
    }
    private void CheckHealth(float Health) {
        if (Health < 0)
        {
            Player player = GetComponent<Player>();
            Debug.Log("DEATH");
            if (player != null)
            {
                player.endGame();
            }
        }
    }
}
