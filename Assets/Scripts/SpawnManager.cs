using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float startDelay = 2f;
    private float repeatRate = 2f;
    private PlayerController playerControllerScript;

    public GameObject[] objectPrefabs;
    private int objectIndex;
    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

   
    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position,
        obstaclePrefab.transform.rotation);
    }
}
