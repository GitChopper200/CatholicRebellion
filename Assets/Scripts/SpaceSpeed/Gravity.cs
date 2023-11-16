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
    
    private Gravity Gravity3;

    private float timer = 10.25f;
    private float waitTime = 5.0f;

    public float Mass = 1;
    private float OtherMass;
    private float G = 6.6743e-11f;

    private Vector3 OwnPosition;
    private Vector3 OtherPosition;

    public float[] GravitationelAccelleration;

    public float GravitationelAccellerationX = 0;
    public float GravitationelAccellerationY = 0;
    public float GravitationelAccellerationZ = 0;


    void Start()
    {
        //Change = GetComponent<PositionChange>();
        ownGravity = GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
            if (timer > waitTime)
            {
                //Debug.Log("a");
                timer = 0.0f;
                forceField();
                OwnPosition = this.transform.position;

                
            }
        }
    // This calculate the force Between two objects, it go through the whole list of objects that it is presented to. 
    void forceField()
    {
        //GravityGameObject = Gravity.FindObjectsOfType(typeof(Gravity));
        GravityGameObject = GameObject.FindGameObjectsWithTag("Gravity");
        for (int counter = 0; counter <  GravityGameObject.Length; counter++)
        {
            if (GravityGameObject[counter] == ownGravity)
            {
                counter++;
            }
            else
            {
                Gravity3 = GravityGameObject[counter].GetComponent<Gravity>();

                OtherMass = Gravity3.Mass;
                OtherPosition = Gravity3.transform.position;

                float distance = Vector3.Distance(OwnPosition, OtherPosition);

                float[] falsevector = new float[3];

                falsevector[0] = OwnPosition.x - OtherPosition.x;
                falsevector[1] = OwnPosition.y - OtherPosition.y;
                falsevector[2] = OwnPosition.z - OtherPosition.z;

                float[] normvector = new float[3];

                normvector[0] = distance - falsevector[0];
                normvector[1] = distance - falsevector[1];
                normvector[2] = distance - falsevector[2];

                GravitationelAccelleration = ForceCalculation(normvector, Mass, OtherMass);

                bool[] minusCon = new bool[3];

                for (int counter2 = 0; ++counter2 < 3; ++counter2) {
                    

                    minusCon[0] = true;
                    minusCon[1] = true;
                    minusCon[2] = true;

                    if (GravitationelAccelleration[counter2] < 0)
                    {
                        minusCon[counter2] = false;
                    }
                
                }
                GravitationelAccellerationX = Mathf.Sqrt(GravitationelAccelleration[0]);
                GravitationelAccellerationY = Mathf.Sqrt(GravitationelAccelleration[1]);
                GravitationelAccellerationZ = Mathf.Sqrt(GravitationelAccelleration[2]);

                if (minusCon[0] == false) {
                    GravitationelAccellerationX = -GravitationelAccellerationX;
                }
                if (minusCon[1] == false)
                {
                    GravitationelAccellerationY = -GravitationelAccellerationY;
                }
                if (minusCon[0] == false)
                {
                    GravitationelAccellerationZ = -GravitationelAccellerationZ;
                }
            }   

        }
    }
    private float[] ForceCalculation(float[] normvector,float ownMass, float otherMass) {
        float mass2 = otherMass * ownMass;
        float mass3 = mass2 * G;

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
