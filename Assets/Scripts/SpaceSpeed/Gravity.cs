using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //private PositionChange Change;
    public GameObject[] GravityGameObject;
    private Gravity ownGravity;
    private Acceleration accelerationScript;
    
    private Gravity Gravity3;

    private float timer = 10.25f;
    private float waitTime = 1.0f;

    public float MassKiloGram = 1;
    private float OtherMass;
    private float G = 6.6743e-11f;

    private Vector3 OwnPosition;
    private Vector3 OtherPosition;
     
    public float[] GravitationelAccellerationFinished;
    
    private float[] GraviationelLocalConverter;
    private float[] GraviationelLocalTransporter;

    public bool newInformation;
    private bool newInformation2;


    void Start()
    {
        MassKiloGram = MassKiloGram * 1000;
        //Change = GetComponent<PositionChange>();
        ownGravity = GetComponent<Gravity>();
        accelerationScript = GetComponent<Acceleration>();

        GravitationelAccellerationFinished = new float[3];
        GraviationelLocalConverter = new float[3];
        GraviationelLocalTransporter = new float[3];

        GravitationelAccellerationFinished[0] = 0;
        GravitationelAccellerationFinished[0] = 0;
        GravitationelAccellerationFinished[0] = 0;

}

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > waitTime && accelerationScript != null)
        {
            //Debug.Log("a");
            GravityGameObject = GameObject.FindGameObjectsWithTag("Gravity");
            GraviationelLocalTransporter[0] = 0;
            GraviationelLocalTransporter[1] = 0;
            GraviationelLocalTransporter[2] = 0;
            // This is the part where everything gets to put into arrays and send to The AccelerationScript
            for (int counter = 0; counter < GravityGameObject.Length; counter++)
            {
                Gravity3 = GravityGameObject[counter].GetComponent<Gravity>();

                OtherMass = Gravity3.MassKiloGram;

                OtherPosition = Gravity3.transform.position;
                OwnPosition = this.transform.position;

                //Debug.LogWarning(counter);
                if (Gravity3 != ownGravity)
                {
      
                    GraviationelLocalConverter = FinalAccelerationVector(MassKiloGram, OtherMass, OwnPosition, OtherPosition);

                    GraviationelLocalTransporter[0] += GraviationelLocalConverter[0];
                    GraviationelLocalTransporter[1] += GraviationelLocalConverter[1];
                    GraviationelLocalTransporter[2] += GraviationelLocalConverter[2];
                   
                    GravitationelAccellerationFinished[0] = GraviationelLocalTransporter[0];
                    GravitationelAccellerationFinished[1] = GraviationelLocalTransporter[1];
                    GravitationelAccellerationFinished[2] = GraviationelLocalTransporter[2];

                    newInformation = true;
                    //Debug.Log(GraviationelLocalConverter[0] + "" + "Converter" + " " + counter);
                    //Debug.Log(GraviationelLocalConverter[0] + "This Is array");
                }
                timer = 0.0f;
            }
            /*if (accelerationScript.CalculateOn == true && accelerationScript != null) {
                GravitationelAccellerationFinished[0] = 0;
                GravitationelAccellerationFinished[1] = 0;
                GravitationelAccellerationFinished[2] = 0;

                newInformation = false;

                // Get the information line to work, so it sets to 0 every time 
            }*/
        }
    }
    // This calculate the force Between two objects, it go through the whole list of objects that it is presented to. 
    private float[] FinalAccelerationVector(float localMass, float LocalOtherMass, Vector3 OwnPos, Vector3 OtherPos)
    {

        float[] unitVector = new float[3];
        float[] gravitationelHelper = new float[3];
        float[] gravitionalAcceleration = new float[3];

        // this is the unitvector look it up on the internet for information. Then it should make sense 
        float distance = Vector3.Distance(OwnPos, OtherPos);
        //her er synderen 
        Vector3 heading = OwnPos - OtherPos;
        /*Debug.LogWarning(heading[0]);
        Debug.LogWarning(heading[1] + "War");
        Debug.LogWarning(heading[2] + "War2");*/
        Vector3 direction = heading / distance;

        float unitVectorCompiner = heading[0] * heading[0] + heading[1] * heading[1] + heading[2] * heading[2];
        float unitVectorDivideHelper = (float)Math.Sqrt(unitVectorCompiner);

        unitVector[0] = heading[0] / unitVectorDivideHelper;
        unitVector[1] = heading[1] / unitVectorDivideHelper;
        unitVector[2] = heading[2] / unitVectorDivideHelper;
        
        //Debug.Log(distance);
        if (distance != 0)
        {
            //Should look like this. gravitationelHelper[0] = -G * (LocalOtherMass) / (distance * distance);
            gravitationelHelper[0] = -G * (LocalOtherMass) / (distance * distance);
            gravitationelHelper[1] = -G * (LocalOtherMass) / (distance * distance);
            gravitationelHelper[2] = -G * (LocalOtherMass) / (distance * distance);
            //Here is the final Gravitationel Acceleration, if you times this with the local mass of its own, you get the force 
            gravitionalAcceleration[0] = (gravitationelHelper[0] * unitVector[0]);
            gravitionalAcceleration[1] = (gravitationelHelper[1] * unitVector[1]);
            gravitionalAcceleration[2] = (gravitationelHelper[2] * unitVector[2]);

          

            return gravitionalAcceleration;
        }else
        {
            float[] zeroArray = new float[3];
            return zeroArray;
        }
    }
        //This calculate the gravitaniol acceleration there is on every axis there is. Return an array 
        private float[] VectorAcceleration(float[] normvector, float ownMass, float otherMass) {
            float mass2 = otherMass * ownMass;

            float supernormalx = normvector[0] * normvector[0];
            float supernormaly = normvector[1] * normvector[1];
            float supernormalz = normvector[2] * normvector[2];

            float forcex = (G * mass2) / supernormalx;
            float forcey = (G * mass2) / supernormaly;
            float forcez = (G * mass2) / supernormalz;

            float[] force = new float[3];

            force[0] = forcex;
            force[1] = forcey;
            force[2] = forcez;

            return force;
        }
}
