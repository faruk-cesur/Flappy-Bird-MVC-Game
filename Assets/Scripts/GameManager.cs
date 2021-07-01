using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        private GameManager(){}
        public static GameManager gameManager;
        
        private void Awake()
        {
            if(gameManager == null)
            {
                gameManager = this;
                DontDestroyOnLoad(this);
            }
            else if(gameManager != this)
            {
                Destroy(gameObject);
            }
        }

        public enum GameState
        {
            Prepare,
            MainGame,
            GameOver,
        }

        public PlayerView player;
        public GameState currentGameState;
        public GameObject prepare;
        public GameObject gameOver;
        public Text scoreText;
        public GameObject scoreboardObject;



        private void Start()
        {
            Model.scoreboard = 0;
            scoreText.text = Model.scoreboard.ToString();
        }

        private void Update()
        {
            ChangeGameState();
        }

        
        // Oyun Durumunu Belirlemek İçin Get&Set Property
        public GameState CurrentGameState
        {
            get { return currentGameState; }
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
                }

                currentGameState = value;
            }

        }

        
        // Anlık Olarak Oyun Durumumuzu Günceller
        private void ChangeGameState()
        {
            switch (gameManager.CurrentGameState)
            {
                case GameState.Prepare:
                    Prepare();
                    break;
                case GameState.MainGame:
                    MainGame();
                    break;
                case GameState.GameOver:
                    FinishGame();
                    break;
            }
        }

        
        // Hazırlık & Başlangıç Aşaması
        private void Prepare()
        {
            Time.timeScale = 1;
            gameOver.SetActive(false);
            scoreboardObject.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                player.Jump();
                CurrentGameState = GameState.MainGame;
            }
            player.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            prepare.gameObject.SetActive(true);
        }

        
        // Oynanış Aşaması
        private void MainGame()
        {
            scoreboardObject.SetActive(true);
            player.rb.constraints = RigidbodyConstraints2D.None;
            prepare.gameObject.SetActive(false);
            player.Jump();
            player.gameObject.transform.eulerAngles = new Vector3(0, 0, player.rb.velocity.y * 5.0f);
        }

        
        // Oyun Bitiş Aşaması
        private void FinishGame()
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

        public void EarnScore()
        {
            Model.scoreboard++;
            scoreText.text = Model.scoreboard.ToString();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }


    }
