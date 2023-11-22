using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[System.Serializable]
public class Gravity : MonoBehaviour
{
    //private PositionChange Change;
    public GameObject[] GravityGameObject;
    private Gravity ownGravity;
    private Acceleration accelerationScript;
    
    private Gravity Gravity3;

    private float timer = 10.25f;
    private float waitTime = 1.0f;

    public float Mass = 1;
    private float OtherMass;
    private float G = 6.6743e-11f;

    private Vector3 OwnPosition;
    private Vector3 OtherPosition;
     
    public float[] GravitationelAccellerationFinished;
    
    private float[] GraviationelLocalConverter;
    private float[] GraviationelLocalTransporter;

    public bool newInformation;


    void Start()
    {
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
        if (timer > waitTime)
        {
            //Debug.Log("a");
            GravityGameObject = GameObject.FindGameObjectsWithTag("Gravity");
            
           // This is the part where everything gets to put into arrays and send to The AccelerationScript
            for (int counter = 0; counter < GravityGameObject.Length; counter++)
            {
                GraviationelLocalTransporter[0] = 0;
                GraviationelLocalTransporter[1] = 0;
                GraviationelLocalTransporter[2] = 0;

                Gravity3 = GravityGameObject[counter].GetComponent<Gravity>();

                if (Gravity3 != ownGravity)
                {
                   
                   

                    OtherMass = Gravity3.Mass;
                        
                    OtherPosition = Gravity3.transform.position;
                    OwnPosition = this.transform.position;

                    GraviationelLocalConverter = forceField(Mass, OtherMass, OwnPosition, OtherPosition);

                    GraviationelLocalTransporter[0] += GraviationelLocalConverter[0];
                    GraviationelLocalTransporter[1] += GraviationelLocalConverter[1];
                    GraviationelLocalTransporter[2] += GraviationelLocalConverter[2];
                   
                    GravitationelAccellerationFinished[0] = GraviationelLocalTransporter[0];
                    GravitationelAccellerationFinished[1] = GraviationelLocalTransporter[1];
                    GravitationelAccellerationFinished[2] = GraviationelLocalTransporter[2];

                    //Debug.Log(GraviationelLocalTransporter[0]);
                    //Debug.Log(GraviationelLocalConverter + "This Is array");
                }
                else
                {
                    Debug.LogWarning("No Movement: " + counter);
                }
                    
                    
                timer = 0.0f;
            }
        }
    }
        // This calculate the force Between two objects, it go through the whole list of objects that it is presented to. 
        private float[] forceField(float localMass, float LocalOtherMass, Vector3 OwnPos, Vector3 OtherPos)
        {
        //GravityGameObject = Gravity.FindObjectsOfType(typeof(Gravity));
            float[] returnForce;
            returnForce = new float[3];
        
            float[] forceNumber;

            float distance = Vector3.Distance(OwnPos, OtherPos);

            Debug.Log(distance);

            float[] falsevector = new float[3];

            falsevector[0] = OwnPos.x - OtherPos.x;
            falsevector[1] = OwnPos.y - OtherPos.y;
            falsevector[2] = OwnPos.z - OtherPos.z;

            float[] normvector = new float[3];

            normvector[0] = distance - falsevector[0];
            normvector[1] = distance - falsevector[1];
            normvector[2] = distance - falsevector[2];

            forceNumber = ForceCalculation(normvector, localMass, LocalOtherMass);

            returnForce[0] = Mathf.Sqrt(forceNumber[0]);
            returnForce[1] = Mathf.Sqrt(forceNumber[1]);
            returnForce[2] = Mathf.Sqrt(forceNumber[2]);

            return returnForce;
        }
        //This calculate the gravitaniol acceleration there is on every axis there is. Return an array 
        private float[] ForceCalculation(float[] normvector, float ownMass, float otherMass) {
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
