using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private PositionChange Change;
    public GameObject[] GravityGameObject;
    private Object ownGravity;
    
    private Gravity Gravity3;

    private float timer = 10.25f;
    private float waitTime = 1.0f;

    public float Mass;
    private float OtherMass;

    private Vector3 OwnPosition;
    private Vector3 OtherPosition;
    void Start()
    {
        Change = GetComponent<PositionChange>();
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
                OtherPosition = Gravity3.OwnPosition;

                float distance = Vector3.Distance(OwnPosition, OtherPosition); 

                


            }

        }
    }
}
