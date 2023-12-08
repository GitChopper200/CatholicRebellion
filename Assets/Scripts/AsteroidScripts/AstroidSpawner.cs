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
        float randomAngle = Random.Range(0f, 360f);
        float angleInRadians = Mathf.Deg2Rad * randomAngle;

        Vector3 spawnPosition = new Vector3(transform.position.x + randomAngle * Mathf.Cos(angleInRadians),
                                            transform.position.y + randomAngle, 
                                            transform.position.z + randomAngle * Mathf.Cos(angleInRadians)
        );
                                            
      




        Debug.Log("njsdgghjdfs");
        GameObject spawnedObject = Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
        
        PositionChange positionChange = GetComponent<PositionChange>();
        
        Vector3 directionToPlayer = (transform.position-spawnedObject.transform.position).normalized;


    }

}