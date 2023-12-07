using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private float powerFromBack = 0.001f;
    public bool ActivateAcceleration;
    public float[] AccelerationPlayer;
    
    private PositionChange positionChange;

    private float timer = 10.25f;
    private float timer2 = 10.25f;
    public float waitTime = 1.0f;
    private float smallWaitTime = 0.125f;

    [SerializeField]
    private TMP_Text SpeedScore;
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
        timer2 += Time.deltaTime;
        if (smallWaitTime < timer2)
        {
            SpeedScore.text = "SpeedX" + positionChange.SpeedX.ToString("0.00") + "\r\n" + "SpeedY" + positionChange.SpeedY.ToString("0.00") + "\r\n" + "SpeedZ" + positionChange.SpeedZ.ToString("0.00");
            timer2 = 0;
        }
    }
    public float[] SetToZero(float SpeedX, float SpeedY, float SpeedZ)
    {
        float[] acceleration = new float[3];
        bool[] closeToZero = new bool[3];
        float threshold = 0.1f;

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

            if (Mathf.Abs(SpeedX) < threshold) {
            closeToZero[0] = true;
            Debug.Log("speedX");
            }
            if (Mathf.Abs(SpeedY) < threshold )
            {
            Debug.Log("speedY");
            closeToZero[1] = true;
            }
            if (Mathf.Abs(SpeedZ) < threshold )
            {
            Debug.Log("speedZ");
            closeToZero[2] = true;
            }
        if (closeToZero[0] == true && closeToZero[1] == true && closeToZero[2] == true)
        {
            positionChange.SpeedX = 0;
            positionChange.SpeedY = 0;
            positionChange.SpeedZ = 0;
            
            AccelerationPlayer[0] = 0;
            AccelerationPlayer[1] = 0;
            AccelerationPlayer[2] = 0;
            
            GetComponent<PositionChange>().enabled = false;
            ActivateAcceleration = false;
        }
        Debug.Log(acceleration[0] + "" + acceleration[1] + "" + acceleration[2]);
        return acceleration;
    }
    

        
}
