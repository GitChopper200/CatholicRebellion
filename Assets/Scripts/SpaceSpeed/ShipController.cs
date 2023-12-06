using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
    private PositionChange PositionChange;

    public float ShipAccelerationX;
    public float ShipAccelerationY;
    public float ShipAccelerationZ;

    private Quaternion rotationQuaternion;

    /*private float timer = 10.25f;
    private float waitTime = 0.125f;*/

    private float powerFromBack = 0.001f;

    private float[] push;

   
    private void Start()
    {
        PositionChange = GetComponent<PositionChange>();

    }
    void Update()
    {
        rotationQuaternion = this.transform.rotation;
        if (Input.GetKey(KeyCode.L))
        {
            Vector3 rotationToAdd = new Vector3(0, 0, 0.1f);
            transform.Rotate(rotationToAdd);
        }
        if (Input.GetKey(KeyCode.K))
        {
            Vector3 rotationToAdd = new Vector3(0, 0, -0.1f);
            transform.Rotate(rotationToAdd);
        }
        if (Input.GetKey(KeyCode.F))
        {
            push = RotationSplit(rotationQuaternion.eulerAngles.y);
            ShipAccelerationX = push[0] * -powerFromBack;
            ShipAccelerationZ = push[1] * -powerFromBack;
        }else if(Input.GetKey(KeyCode.R)){
            push = RotationSplit(rotationQuaternion.eulerAngles.y);
            ShipAccelerationX = push[0] * powerFromBack;
            ShipAccelerationZ = push[1] * powerFromBack;
        }

        else
        {
            ShipAccelerationX = 0;
            ShipAccelerationZ = 0;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            ShipAccelerationY = +powerFromBack;
        }
        else if (Input.GetKey(KeyCode.X))
        {
            ShipAccelerationY = -powerFromBack;
        }
        else
        {
            ShipAccelerationY = 0;
        }


        //Debug.Log(rotationQuaternion.eulerAngles.y + "y");
        //Debug.Log(rotationQuaternion.eulerAngles.z + "z");

    }
    private float[] RotationSplit(float Roation)
    {
        float[] pushFrom = new float[2];
        if (Roation >= 0 && Roation <= 90 || Roation < -270 && Roation >= -360)
        {
            pushFrom[0] = 0.011111111111f * Roation + 1;
            pushFrom[1] = 1 - pushFrom[0];
        }
        if (Roation > 90 && Roation <= 180 || Roation < -180 && Roation >= -270)
        {
            pushFrom[0] = -0.011111111111f * Roation;
            pushFrom[1] = pushFrom[0] - 1;
        }
        if (Roation > 180 && Roation <= 270 || Roation < -90 && Roation >= -180) {
            pushFrom[0] = -0.011111111111f * Roation - 1;
            pushFrom[1] = 1 - pushFrom[0];

        }
        if (Roation > 270 && Roation <= 360 || Roation < 0 && Roation >= -90) 
        {
            pushFrom[0] = 0.011111111111f * Roation;
            pushFrom[1] = pushFrom[0] - 1;
        }
        return pushFrom;

    }
}
