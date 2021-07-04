using System;
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
    private GameState _currentGameState;
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.Prepare:
                    break;
                case GameState.MainGame:
                   
                    break;
                case GameState.GameOver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            _currentGameState = value;
        }
    }
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
    private PlayerModel playerModel;
    public Animator groundAnimator;

    // Oyun durumu güncellemesi sürekli olarak kontrol ediliyor.

    private void Start()
    {
        playerModel = _playerController.playerModel;
    }

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

    public void LoseGame()
    {
        StartCoroutine(LoseGameControl());
    }

    IEnumerator LoseGameControl()
    {
        player.GetComponent<Animator>().enabled = false;
        groundAnimator.enabled = false;
        AudioSource.PlayClipAtPoint(deathSound,player.gameObject.transform.position);
        yield return new WaitForSeconds(1f);
        currentScoreText.text = playerModel.score.ToString();
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerModel.score);
            goldMedal.SetActive(true);
            newScore.SetActive(true);
        }
        if (playerModel.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerModel.score);
            playerModel.medalScore = playerModel.score + 1;
        }
        if (playerModel.medalScore > PlayerPrefs.GetInt("HighScore") )
        {
            goldMedal.SetActive(true);
            newScore.SetActive(true);
            AudioSource.PlayClipAtPoint(highScoreSound,player.gameObject.transform.position);
        }
        else
        {
            silverMedal.SetActive(true);
        }
       

        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        //Time.timeScale = 0;
        gameOver.SetActive(true);
        scoreboardObject.SetActive(false);
    }
}