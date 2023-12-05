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
        
        float TotalSpeedTotal = (TotalOtherSpeed + TotalSpeed) * otherMass;
        Debug.Log(TotalSpeedTotal);
        TotalSpeedTotal = Mathf.Abs(TotalSpeedTotal);
        health = health - TotalSpeedTotal;
        CheckHealth();
        return health;
    }
    void CheckHealth() { 
        Player player = GetComponent<Player>();
        if(player != null)
        {
            player.endGame();

        }
    }
}
