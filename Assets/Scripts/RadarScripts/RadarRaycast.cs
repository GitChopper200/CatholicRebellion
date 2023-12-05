using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRaycast : MonoBehaviour
{  
    public float maxRayDistance = 10f;
    public Renderer radarPingSprite;
    public float fadeDelay = 2f;
    public float fadeDuration = 1f;
    [ColorUsageAttribute(true, true)]
    public Color pingColor;

    List<Renderer> pingPool = new List<Renderer>();


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
                Renderer currentPing = null;
                if (pingPool.Count > 0)
                {
                    currentPing = pingPool[pingPool.Count - 1];
                   
                    currentPing.material.SetColor("_EmissionColor", pingColor);

                    pingPool.RemoveAt(pingPool.Count-1);
                    currentPing.transform.position = hit.point;
                    currentPing.enabled = true;
                }
                else
                {
                    currentPing = Instantiate(radarPingSprite, hit.point, Quaternion.identity);
                    currentPing.material.SetColor("_EmissionColor", pingColor);
                }

                StartCoroutine(FadeOutCoroutine(currentPing));
                //Invoke("FadeOut",fadeDelay);

                
            }

            
        }
        Debug.DrawLine(transform.position,transform.position+transform.forward*maxRayDistance);
    
   
    }
    void FadeOut()
    {
        Renderer renderer = GetComponent<Renderer>();
        Debug.Log("dfblks");
        if(renderer != null)
        {
            StartCoroutine(FadeOutCoroutine(renderer));
        }
    }

    IEnumerator FadeOutCoroutine(Renderer renderer)
    {
        float start = Time.time;
        while (start + fadeDelay > Time.time)
        {
            yield return null;
        }

        float alpha = 1f;

        float fadeStep = 1f / fadeDuration;

        while (alpha > 0)
        {
            alpha -= fadeStep*Time.deltaTime;

            Color newColor = renderer.material.GetColor("_EmissionColor");
            newColor = pingColor * alpha;
            renderer.material.SetColor("_EmissionColor", newColor);

            yield return null;
        }

        Color newColorFinal = renderer.material.GetColor("_EmissionColor");
        newColorFinal = pingColor * 0;
        renderer.material.SetColor("_EmissionColor", newColorFinal);
        renderer.enabled = false;
        pingPool.Add(renderer); 
    }
}

