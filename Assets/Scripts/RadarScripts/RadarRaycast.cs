using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRaycast : MonoBehaviour
{  
    public float maxRayDistance = 10f;
    public GameObject radarPingSprite;
    public float fadeDelay = 2f;
    public float fadeDuration = 1f;

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
            if(radarPingSprite != null)
            {
                Instantiate(radarPingSprite, hit.point, Quaternion.identity);

                Invoke("FadeOut", fadeDelay);

                Debug.Log("btichass");
            }

            Debug.Log("RadarHit"+hit.transform.name);
        }
        Debug.DrawLine(transform.position,transform.position+transform.forward*maxRayDistance);
    
   
    }
        void FadeOut()
    {
        Renderer renderer = GetComponent<Renderer>();

        if(renderer != null)
        {
            StartCoroutine(FadeOutCoroutine(renderer));
        }
    }

    IEnumerator FadeOutCoroutine(Renderer renderer)
    {
        float alpha = 1f;

        float fadeStep = 1f / fadeDuration;

        while (alpha > 0f)
        {
            alpha -= fadeStep*Time.deltaTime;
            Color newColor=renderer.material.color;
            newColor.a = alpha;
            renderer.material.color = newColor;

            yield return null;
        }
        Destroy(gameObject);
    }
}

