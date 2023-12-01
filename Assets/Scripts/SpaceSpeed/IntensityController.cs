using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class IntensityController : MonoBehaviour
{
    public Camera camera;
    public Light sun;
    
    public float maxDist;

    public float minIntensity;
    public float maxIntensity;
    public AnimationCurve intensityCurve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sun && (camera || !Application.isPlaying) && intensityCurve != null)
        {
            Camera currentCam = camera;
            if (!Application.isPlaying)
            {
                currentCam = Camera.current;
            }
            if (currentCam)
            {
                float factor = Mathf.Clamp01(Vector3.Distance(currentCam.transform.position, sun.transform.position) / maxDist);

                sun.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensityCurve.Evaluate(factor));
            }
        }
    }
}
