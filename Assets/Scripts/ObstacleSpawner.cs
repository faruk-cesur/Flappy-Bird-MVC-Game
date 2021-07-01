using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    private float minDistance = -1.5f;
    private float maxDistance = 3.0f;
    private GameManager _gameManager;
    private Vector3 position;

    private void Start()
    {
        StartCoroutine(SpawnObstacles(2));
    }

    private void Update()
    {
        
    }

    public IEnumerator SpawnObstacles(float time)
    {
        // while(GameManager.gameManager.currentGameState == GameManager.GameState.MainGame)
        // {
        //     Instantiate(obstacle, new Vector3(3.3f, Random.Range(minDistance,maxDistance), 0), Quaternion.identity);
        //     yield return new WaitForSeconds(2f);
        // }
        
        while(true)
        {
            Instantiate(obstacle, new Vector3(3.3f, Random.Range(minDistance,maxDistance), 0), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}