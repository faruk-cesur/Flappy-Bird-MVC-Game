using System;
using UnityEngine;

// (MVC) - Controller Burada Tutuluyor.
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        public enum GameState
        {
            Prepare,
            MainGame,
            FinishGame,
        }

        public PlayerController player;
        private GameState currentGameState;
        public GameObject prepare;

        private void Awake()
        {
            gameManager = this;
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
                    case GameState.FinishGame:
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
                case GameState.FinishGame:
                    FinishGame();
                    break;
            }
        }

        
        // Hazırlık & Başlangıç Aşaması
        private void Prepare()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CurrentGameState = GameState.MainGame;
            }
            player.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            prepare.gameObject.SetActive(true);
        }

        
        // Oynanış Aşaması
        private void MainGame()
        {
            player.rb.constraints = RigidbodyConstraints2D.None;
            player.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            prepare.gameObject.SetActive(false);
            player.Jump();
            player.gameObject.transform.eulerAngles = new Vector3(0, 0, player.rb.velocity.y * 5.0f);
        }

        
        // Oyun Bitiş Aşaması
        private void FinishGame()
        {
            
        }


    }
