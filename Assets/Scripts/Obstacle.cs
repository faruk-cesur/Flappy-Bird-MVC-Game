using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Obstacle objelerimizin hareket hızı değişkeni
    private float moveSpeed = 2f;


    // Obstacle objelerimizin oluşturulduktan dört saniye sonra yok olmalarını sağlıyoruz. (Performans için)
    private void Start()
    {
        Destroy(gameObject, 4f);
    }


    // MoveObstacle Metodumuzu çağırıp bize doğru hareket etmesini sağlıyoruz
    private void FixedUpdate()
    {
        MoveObstacle();
    }


    // Obstacle objelerimizin bize doğru hareket etmesini sağlar.
    private void MoveObstacle()
    {
        if (GameManager.gameManager.CurrentGameState == GameManager.GameState.MainGame)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}