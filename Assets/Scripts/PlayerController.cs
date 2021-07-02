using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController
    {
        public PlayerView playerView;
        public PlayerModel playerModel;

        public PlayerController(PlayerView view)
        {
            playerModel = new PlayerModel();
            playerView = view;
        }
        
        public enum GameState
        {
            Prepare,
            MainGame,
            GameOver,
        }
        
        
        public GameState CurrentGameState;
        
         // Oyun Durumunu Belirlemek İçin Get&Set Property
       
     public void ChangeGameState()
     {
         switch (CurrentGameState)
         {
             case GameState.Prepare:
                 Prepare();
                 break;
             case GameState.MainGame:
                 Debug.Log("main");
                 MainGame();
                 break;
             case GameState.GameOver:
                 GameOver();
                 break;
         }
     }
    
     
     // Hazırlık & Başlangıç Aşaması
     private void Prepare()
     {
         Time.timeScale = 1;
         GameManager.gameManager.gameOver.SetActive(false);
         GameManager.gameManager.scoreboardObject.SetActive(false);
         playerView.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
         GameManager.gameManager.prepare.gameObject.SetActive(true);
     }
    
     
     // Oynanış Aşaması
     private void MainGame()
     {
         GameManager.gameManager.scoreboardObject.SetActive(true);
         playerView.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
         GameManager.gameManager.prepare.gameObject.SetActive(false);
         playerView.Jump();
         playerView.transform.eulerAngles = new Vector3(0, 0, playerView.gameObject.GetComponent<Rigidbody2D>().velocity.y * 5.0f);
     }
    
     
     // Oyun Bitiş Aşaması
     private void GameOver()
     {
         if (!PlayerPrefs.HasKey("HighScore"))
         {
             PlayerPrefs.SetInt("HighScore",playerModel.score);
         }
         if (playerModel.score > PlayerPrefs.GetInt("HighScore"))
         {
             PlayerPrefs.SetInt("HighScore",playerModel.score);
         }
         GameManager.gameManager.highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
         Time.timeScale = 0;
         GameManager.gameManager.gameOver.SetActive(true);
         GameManager.gameManager.scoreboardObject.SetActive(false);
     }


        public void Jumping()
        {
            playerView.rb.velocity = Vector2.up * playerModel.jumpPower;
        }
        
        public void EarnScore()
        {
            playerModel.score++;
            GameManager.gameManager.scoreText.text = playerModel.score.ToString();
        }

    }