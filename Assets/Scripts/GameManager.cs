using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;
        
        private void Awake()
        {
            _playerController = new PlayerController(player);
            if(gameManager == null)
            {
                gameManager = this;
            }
            else if(gameManager != this)
            {
                Destroy(gameObject);
            }
        }
        
        public GameObject prepare;
        public GameObject gameOver;
        public Text scoreText;
        public Text highScoreText;
        public GameObject scoreboardObject;
        public PlayerView player;
        private PlayerModel _playerModel = new PlayerModel();
        public PlayerController _playerController;
        

        private void Update()
        {
            _playerController.ChangeGameState();
        }
        


        public void RestartGame()
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
