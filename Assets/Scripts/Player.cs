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
    private ShipController shipController;

    private float timer = 10.25f;
    private float timer2 = 10.25f;
    public float waitTime = 1.0f;
    private float smallWaitTime = 0.125f;

    private float[] speedText;
    private int speedTimer = 10;
    private float[] pushProcent;
    private float[] falsePushProcent;

    private Vector3 WinTransform;

    [SerializeField]
    private TMP_Text SpeedScore;
    [SerializeField]
    private TMP_Text TransformPosition;
    [SerializeField]
    private TMP_Text WinText;
    [SerializeField]
    private TMP_Text Rotation;
    public void endGame() 
    {
        Application.Quit();
    }
    public void WinGame()
    {
        Debug.Log("Win");
    }
    void Start()
    {
    positionChange = GetComponent<PositionChange>();
    shipController = GetComponent<ShipController>();

    AccelerationPlayer = new float[3];
    speedText = new float[3];
    pushProcent = new float[2];
    falsePushProcent = new float[2];

    AccelerationPlayer[0] = 0;
    AccelerationPlayer[1] = 0;
    AccelerationPlayer[2] = 0;

    GameObject[] win = GameObject.FindGameObjectsWithTag("Win");
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
            speedText[0] = positionChange.SpeedX * speedTimer;
            speedText[1] = positionChange.SpeedY * speedTimer;
            speedText[2] = positionChange.SpeedZ * speedTimer;
            SpeedScore.text = "SpeedX" + speedText[0].ToString("0.00") + "\r\n" + "SpeedY" + speedText[1].ToString("0.00") + "\r\n" + "SpeedZ" + speedText[2].ToString("0.00");

           
            TransformPosition.text = "x" + positionChange.positionOwn[0].ToString("0.0") + "\r\n" + "y" + positionChange.positionOwn[1].ToString("0.0") + "\r\n" + "z" + positionChange.positionOwn[2].ToString("0.0");


            WinText.text = "WinPostion" + "\r\n" + "x" + WinTransform.x.ToString("0.0") + "\r\n" + "y" + WinTransform.y.ToString("0.0") + "\r\n" + "z" + WinTransform.z.ToString("0.0");

            falsePushProcent = shipController.RotationSplit(this.transform.rotation.eulerAngles.y);

            pushProcent[0] = falsePushProcent[0] / falsePushProcent[1];
            pushProcent[1] = falsePushProcent[1] / falsePushProcent[0];

            pushProcent[0] *= 10;
            pushProcent[1] *= 10;

            Rotation.text = "Rotation" + "\r\n" + "pushInX" + pushProcent[0].ToString("0") + "%" + "\r\n" + "pushInZ" + pushProcent[1].ToString("0") + "%";


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
