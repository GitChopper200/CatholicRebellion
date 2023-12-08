using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public float speed = 2f;

    public float spawnDelay = 2f;
    
    public GameObject spawnPrefab;

    public float timer;
    public float countDownTimer = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
       

        
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 )
        {
            Debug.Log("Timer Countdown Over");
            StartCoroutine(SpawnCoroutine());
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer = countDownTimer;
    }


    IEnumerator SpawnCoroutine()
    {
       yield return new WaitForSeconds(spawnDelay);

        SpawnAsteroid();
    }

    void SpawnAsteroid()
    {
        Debug.Log("njsdgghjdfs");
        GameObject spawnedObject = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        
        Vector3 directionToPlayer = (transform.position-spawnedObject.transform.position).normalized;
        
        spawnedObject.transform.position += directionToPlayer * speed * Time.deltaTime;

    }

}
