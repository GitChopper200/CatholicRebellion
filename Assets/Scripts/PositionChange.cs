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
    private float timer = 10.0f;
    private float waitTime = 1.0f;

    private float SpeedX = 0;
    private float SpeedY = 0;
    private float SpeedZ = 0;

    public float accelerationX = 0.01f;
    public float accelerationY = 0.01f;
    public float accelerationZ = 0.0f;

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

    //This changes the position of the object, simply making it fly arond from the speed
    public Vector3 PositionsChange(float SpeedX, float SpeedY, float SpeedZ, Vector3 postition)
    {
        postition[0] = postition[0] + SpeedX;
        postition[1] = postition[1] + SpeedY;
        postition[2] = postition[2] + SpeedZ;
        return postition;
    }
    //This calcurlate the speed of every object, and take the acceleration as consideration
    public float Acceleration(float speed, float acceleration)
    {
        speed = acceleration + speed;

        return speed;
    }
}

