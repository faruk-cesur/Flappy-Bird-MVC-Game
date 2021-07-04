using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton Kullanımı
    public static GameManager gameManager;

    private void Awake()
    {
        _playerController = new PlayerController(player);
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    // Oyun Durumları Belirlendi
    public enum GameState
    {
        Prepare,
        MainGame,
        GameOver,
    }

    // Değişkenler ve referanslar alındı
    public GameState currentGameState;
    public Text scoreText;
    public Text highScoreText;
    public Text currentScoreText;
    public GameObject prepare;
    public GameObject gameOver;
    public GameObject scoreboardObject;
    public GameObject goldMedal;
    public GameObject silverMedal;
    public GameObject newScore;
    public AudioClip scoreSound;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip startSound;
    public AudioClip highScoreSound;
    public PlayerView player;
    public PlayerController _playerController;


    // Oyun durumu güncellemesi sürekli olarak kontrol ediliyor.
    private void Update()
    {
        _playerController.ChangeGameState();
    }


    // Oyunu tekrar başlatmayı sağlayan buton komutu.
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

   
}