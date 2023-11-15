using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class PositionChange : MonoBehaviour
{
    //This is from The 
    public GameObject anotherCircel;

    private Acceleration AccelerationScript;

    public int mass = 0;
    private float timer = 10.25f;
    public float waitTime = 0.05f;
    
    public float SpeedX = 0;
    public float SpeedY = 0;
    public float SpeedZ = 0;

    private void Start()
    {
        AccelerationScript = GetComponent<Acceleration>();
    }

    void Update()
    {
        //This is just a testTimer to test if things work. We look at this after sometimes later
        //This also check acceleration and call for the functions, to 
        timer += Time.deltaTime;
        if (waitTime < timer)
        {


            Vector3 positionOwn = this.transform.position;

            //Here is the reference to the script so that the acceleration is been taken in the script. And the change of position and speed is taken in here. Q
            SpeedX = AccelerationScript.AccelerationFunction(SpeedX, AccelerationScript.accelerationX);
            SpeedY = AccelerationScript.AccelerationFunction(SpeedY, AccelerationScript.accelerationY);
            SpeedZ = AccelerationScript.AccelerationFunction(SpeedZ, AccelerationScript.accelerationZ);
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
}

