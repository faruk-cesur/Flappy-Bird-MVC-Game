using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

// (MVC) - View  Burada tutuluyor.

    public class PlayerView : MonoBehaviour
    {
        public Rigidbody2D rb;
        private PlayerController _playerController;
        public PlayerController.GameState currentGameState;
        
        private void Start()
        {
            _playerController = GameManager.gameManager._playerController;
            rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentGameState = PlayerController.GameState.MainGame;
            }

            _playerController.ChangeGameState();
        }


        // Her tıklandığında kuş zıplar (MainGame State)
        public void Jump()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerController.Jumping();
            }
        }


        public void OnCollisionEnter2D(Collision2D other)
        {
            _playerController.CurrentGameState = PlayerController.GameState.GameOver;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("ScoreArea"));
            {
                _playerController.EarnScore();
            }

        }
    }
