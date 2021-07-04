using UnityEngine;


// (MVC Design Pattern) - Controller Burada tutuluyor.
public class PlayerController
{
    public PlayerView playerView;
    public PlayerModel playerModel;

    public PlayerController(PlayerView view)
    {
        playerModel = new PlayerModel();
        playerView = view;
    }


    // Oyun durumları arasında switch yapısı ile geçiş yapılıyor ve içindeki metodlar çalıştırılıyor.
    public void ChangeGameState()
    {
        switch (GameManager.gameManager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                Prepare();
                break;
            case GameManager.GameState.MainGame:
                MainGame();
                break;
            case GameManager.GameState.GameOver:
                GameOver();
                break;
        }
    }


    // Oyun Hazırlık & Başlangıç Aşaması
    private void Prepare()
    {
        //Time.timeScale = 1;
        GameManager.gameManager.gameOver.SetActive(false);
        GameManager.gameManager.scoreboardObject.SetActive(false);
        playerView.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        GameManager.gameManager.prepare.gameObject.SetActive(true);
        playerView.transform.position = playerView.transform.up * Mathf.PingPong(Time.time, .5f);
       
    }


    // Oyun Oynanış Aşaması
    private void MainGame()
    {
        if (!_control)
        {
            _control = true;
            AudioSource.PlayClipAtPoint(GameManager.gameManager.startSound,playerView.gameObject.transform.position);
        }
        GameManager.gameManager.scoreboardObject.SetActive(true);
        playerView.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameManager.gameManager.prepare.gameObject.SetActive(false);
        playerView.Jump();
        playerView.transform.eulerAngles = new Vector3(0, 0,
            playerView.gameObject.GetComponent<Rigidbody2D>().velocity.y * playerModel.eulerAngles);
    }

    private bool _control;
    
    
    // Oyun Bitiş Aşaması
    private void GameOver()
    {
        if (_control)
        {
            _control = false;
            GameManager.gameManager.LoseGame();
        }
    }


    // Karakterin zıplamasını sağlayan method.
    public void Jumping()
    {
        playerView.rb.velocity = Vector2.up * playerModel.jumpPower;
        AudioSource.PlayClipAtPoint(GameManager.gameManager.jumpSound, playerView.gameObject.transform.position);
    }

    // Puan kazanmamızı ve skorumuzun güncellenmesini sağlayan metod.
    public void EarnScore()
    {
        playerModel.score++;
        GameManager.gameManager.scoreText.text = playerModel.score.ToString();
        AudioSource.PlayClipAtPoint(GameManager.gameManager.scoreSound, playerView.gameObject.transform.position);
    }
}