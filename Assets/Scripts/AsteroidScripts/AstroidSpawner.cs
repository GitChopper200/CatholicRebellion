using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public float speed = 2f;

    public float spawnDelay = 2f;

    public float spawnRadius = 5f;

    public GameObject spawnPrefab;

    public float timer;
    public float countDownTimer = 5f;

    private Vector3 initialParentPosition;

    private Vector3 moveDirection;

    private GameObject Ship;


    // Start is called before the first frame update
    void Start()
    {
        Ship = GameObject.Find("SpacecraftPlayer");
    }
    void Update()
    {
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Debug.Log("Timer Countdown Over");
                StartCoroutine(SpawnCoroutine());
                ResetTimer();
            }

        }
    }

    void ResetTimer()
    {
        timer = countDownTimer;
    }


    IEnumerator SpawnCoroutine()
    {
        initialParentPosition = transform.position;

        yield return new WaitForSeconds(spawnDelay);

        SpawnAsteroid();
    }

    void SpawnAsteroid()
    {
        float randomAngle = 2f;
        float angleInRadians = Mathf.Deg2Rad * randomAngle;


        Vector3 spawnPosition = new Vector3(transform.position.x + spawnRadius * Mathf.Cos(angleInRadians),
                                            transform.position.y + spawnRadius,
                                            transform.position.z + spawnRadius * Mathf.Cos(angleInRadians)
        );


        Debug.Log("njsdgghjdfs");
        GameObject spawnedObject = Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
        PositionChange asteroidPositionChamge = spawnedObject.GetComponent<PositionChange>();
        // Vector3 initialPosition = spawnedObject.transform.position;

        // Vector3 directionToPlayer = (transform.position-spawnedObject.transform.position).normalized;

        //StartCoroutine(MovePrefab(spawnedObject, initialParentPosition));
        DirectionLocalFunction(asteroidPositionChamge, spawnPosition, Ship.transform.position, 1);


    }
    void DirectionLocalFunction(PositionChange posChange, Vector3 ownPosition, Vector3 OtherDirection, float SpeedBonus)
    {
        Vector3 heading = OtherDirection - ownPosition;

        float[] unitVector = new float[3];

        float unitVectorCompiner = heading[0] * heading[0] + heading[1] * heading[1] + heading[2] * heading[2];
        float unitVectorDivideHelper = (float)Math.Sqrt(unitVectorCompiner);

        unitVector[0] = heading[0] / unitVectorDivideHelper;
        unitVector[1] = heading[1] / unitVectorDivideHelper;
        unitVector[2] = heading[2] / unitVectorDivideHelper;

        unitVector[0] *= SpeedBonus;
        unitVector[1] *= SpeedBonus;
        unitVector[2] *= SpeedBonus;


        SetSpawnerSpeed(posChange, unitVector[0], unitVector[1], unitVector[2]);
    }
    void SetSpawnerSpeed(PositionChange posChamge, float SpeedX, float SpeedY, float SpeedZ)
    {
        posChamge.SpeedX = SpeedX;
        posChamge.SpeedY = SpeedY;
        posChamge.SpeedZ = SpeedZ;

    }
}
