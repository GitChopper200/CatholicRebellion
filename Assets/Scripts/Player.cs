using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float powerFromBack = 0.001f;
    public bool ActivateAcceleration;
    public float[] AccelerationPlayer;
    
    private PositionChange positionChange;

    private float timer = 10.25f;
    public float waitTime = 1.0f;
    public void endGame() {

        Application.Quit();

        

    }
    void Start()
    {
     positionChange = GetComponent<PositionChange>();
        
    AccelerationPlayer = new float[3];

    AccelerationPlayer[0] = 0;
    AccelerationPlayer[1] = 0;
    AccelerationPlayer[2] = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (waitTime < timer)
        {
            if (ActivateAcceleration == true)
            {
                AccelerationPlayer = SetToZero(positionChange.SpeedX, positionChange.SpeedY, positionChange.SpeedZ);
            }

            timer = 0;
        }

    }
    public float[] SetToZero(float SpeedX, float SpeedY, float SpeedZ)
    {
        float[] acceleration = new float[3];

            if (SpeedX < 0)
            {
            acceleration[0] += powerFromBack;
            }
            else if (SpeedX > 0)
            {
            acceleration[0] -= powerFromBack;
            }
            if (SpeedY < 0)
            {
            acceleration[1] += powerFromBack;
            }
            else if (SpeedY > 0)
            {
            acceleration[1] -= powerFromBack;
            }
            if (SpeedZ < 0)
            {
            acceleration[2] += powerFromBack;
            }
            else if (SpeedZ > 0)
            {
            acceleration[2] -= powerFromBack;
            }
        Debug.Log(acceleration[0] + "" + acceleration[1] + "" + acceleration[2]);
        return acceleration;
    }
    

        
}
