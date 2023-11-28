using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class ShipController : MonoBehaviour
{
    private PositionChange PositionChange;
    private Transform rotation;

    public float ShipAccelerationX;
    public float ShipAccelerationY;
    public float ShipAccelerationZ;

    private Quaternion rotationQuaternion;
    private float roationX;

    private float timer = 10.25f;
    private float waitTime = 0.125f;

    private float powerFromBack = 0.0001f;

    private float pushFromX;
    private float pushFromZ;
    private void Start()
    {
        PositionChange = GetComponent<PositionChange>();
        rotation = GetComponent<Transform>();

        rotationQuaternion = transform.rotation;
       
        roationX = 90 + rotationQuaternion.eulerAngles.x;
        
        //Debug.LogWarning(roationX);


        //waitTime = PositionChange.waitTime;
    }
    void Update()
    {
        
        

        
        /*timer += Time.deltaTime;
        if (timer > waitTime)*/
        {
            rotationQuaternion = transform.rotation;
            if (Input.GetKeyDown(KeyCode.L))
            {
                this.transform.rotation = Change(-90f, 0, rotationQuaternion.eulerAngles.z + 1.0f);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                this.transform.rotation = Change(-90f, 0, rotationQuaternion.eulerAngles.z - 1.0f);
            }
            if (Input.GetKey(KeyCode.F))
            {
                ShipAccelerationY = pushFromX * powerFromBack;
                ShipAccelerationZ = pushFromZ * powerFromBack;
            }
           

            //Debug.Log(rotationQuaternion.eulerAngles.y + "y");
            //Debug.Log(rotationQuaternion.eulerAngles.z + "z");
            if (rotationQuaternion.eulerAngles.y >= 0 && rotationQuaternion.eulerAngles.y <= 180)
            { 
                pushFromX = -0.011111111111f * rotationQuaternion.eulerAngles.y + 1.0f;
                if (rotationQuaternion.eulerAngles.y >= 90)
                {
                    pushFromZ = 1 + pushFromX;
                }
                else
                {
                    pushFromZ = 1 - pushFromX;
                }
            
            }
            if(rotationQuaternion.eulerAngles.y > 180)
            {
                pushFromX = 0.011111111111f * rotationQuaternion.eulerAngles.y - 3.0f;
                if (rotationQuaternion.eulerAngles.y >= 270)
                {
                    pushFromZ = 1 - pushFromX;
                }
                else
                {
                    pushFromZ = 1 + pushFromX;
                }
            }
            Debug.Log(pushFromX + "pushX");
            Debug.Log(pushFromZ + "pushZ");


            //ShipAccelerationX = 0;
            //ShipAccelerationY = 0;
            //ShipAccelerationZ = 0;

            //timer = 0;
        }

       
    }
    private static Quaternion Change(float x, float y, float z)
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(x, y, z, 1);
        //Return the new Quaternion
        return newQuaternion;
    }
}
