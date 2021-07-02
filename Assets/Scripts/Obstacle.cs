using UnityEngine;

public class Obstacle : MonoBehaviour
{
   private float moveSpeed = 2f;

   private void Start()
   {
      Destroy(gameObject,4f);
   }

   private void FixedUpdate()
   {
      MoveObstacle();
   }

   private void MoveObstacle()
   {
      if (GameManager.gameManager.currentGameState == GameManager.GameState.MainGame)
      {
         transform.position += Vector3.left * moveSpeed * Time.deltaTime;
      }
   }
}
