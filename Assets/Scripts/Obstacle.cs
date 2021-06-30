using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;
public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    private float minDistance = -2.20f;
    private float maxDistance = 3.3f;
    private GameManager managerGame;
    private Vector3 position;

    private void Start()
    {
        StartCoroutine(SpawnObstacles(2));
        Destroy(gameObject,1);
    }

    private void Update()
    {
        
    }

    public IEnumerator SpawnObstacles(float time)
    {
        while(true){
            Instantiate(obstacle, new Vector3(1, Random.Range(minDistance,maxDistance), 0), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}