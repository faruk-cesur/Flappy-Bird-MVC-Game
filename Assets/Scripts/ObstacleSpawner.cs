using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleSpawner : MonoBehaviour
{
    // Obstacle objeleri için değişkenler
    public GameObject obstacle;
    private float minDistance = -1.5f;
    private float maxDistance = 3.0f;
    private Vector3 position;


    // IEnumerator Coroutine metodumuzu çağırıyoruz.
    private void Start()
    {
        StartCoroutine(SpawnObstacles(2));
    }


    // Obstacle objelerinin rastgele Y değerlerinde iki saniyede bir oluşturulmasını sağlıyoruz
    public IEnumerator SpawnObstacles(float time)
    {
        while (true)
        {
            if (GameManager.gameManager.CurrentGameState == GameManager.GameState.MainGame)
            {
                Instantiate(obstacle, new Vector3(3.3f, Random.Range(minDistance, maxDistance), 0),
                    Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            else
            {
                yield return new WaitForSeconds(2f);
            }
        }
    }
}