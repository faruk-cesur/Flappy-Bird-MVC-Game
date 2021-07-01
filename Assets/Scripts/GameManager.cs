using System;
using UnityEngine;
using UnityEngine.UI;

// (MVC) - Controller Burada Tutuluyor.
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        public enum GameState
        {
            Prepare,
            MainGame,
            GameOver,
        }

        public PlayerController player;
        public GameState currentGameState;
        public GameObject prepare;
        public GameObject gameOver;
        public Text scoreText;
        public GameObject scoreboardObject;

        private void Awake()
        {
            gameManager = this;
        }

        private void Start()
        {
            Score.scoreboard = 5;
            scoreText.text = Score.scoreboard.ToString();
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


    }
