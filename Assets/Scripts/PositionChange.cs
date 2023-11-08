using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class PositionChange : MonoBehaviour
{
   
    public GameObject anotherCircel;
    public int mass = 0;
    public float timer = 10.0f;
    public float timeSeter;
    public float waitTime = 1.0f;

    public float SpeedX = 0;
    public float SpeedY = 0;
    public float SpeedZ = 0;

    public float accelerationX = 0.01f;
    public float accelerationY = 0.01f;
    public float accelerationZ = 0.0f;


    void Start()
    {
        // This part of the code is made for the to recieve information  of about onceself object and just put it in 
        /*Vector3 position = anotherCircel.transform.position;
        Debug.Log(position);
        xCordinat = position[0];
        Debug.Log(xCordinat);*/
    }

    void Update()
    {
        //This is just a testTimer to test if things work. We look at this after sometimes 
        timer += Time.deltaTime;
        if (waitTime < timer)
        {
            Vector3 positionOwn = this.transform.position;
            SpeedX = Acceleration(SpeedX, accelerationX);
            SpeedY = Acceleration(SpeedY, accelerationY);
            SpeedZ = Acceleration(SpeedZ, accelerationZ);
            this.transform.position = PositionsChange(SpeedX, SpeedY, SpeedZ, positionOwn);
            timer = 0;
        }

    }

    public Vector3 PositionsChange(float SpeedX, float SpeedY, float SpeedZ, Vector3 postition)
    {
        postition[0] = postition[0] + SpeedX;
        postition[1] = postition[1] + SpeedY;
        postition[2] = postition[2] + SpeedZ;
        return postition;
    }
    public float Acceleration(float speed, float acceleration)
    {
        speed = acceleration + speed;

        return speed;
    }
}

