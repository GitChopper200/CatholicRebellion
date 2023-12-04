using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRaycast : MonoBehaviour
{  
    public float maxRayDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.Log("RadarHit"+hit.transform.name);
        }
        Debug.DrawLine(transform.position,transform.position+transform.forward*maxRayDistance);
    }
}
