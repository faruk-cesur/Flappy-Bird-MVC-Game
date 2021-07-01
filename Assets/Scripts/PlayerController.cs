using System;
using UnityEngine;

// (MVC) - View  Burada tutuluyor.

    public class PlayerController : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float jumpPower;
        private GameManager _gameManager;
        

        private void Start()
        {
            jumpPower = 5f;
            rb = GetComponent<Rigidbody2D>();
        }
        

        private void Update()
        {

        }
        
        
        
        // Her tıklandığında kuş zıplar (MainGame State)
        public void Jump()
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * jumpPower; 
            }
        }


        public void OnCollisionEnter2D(Collision2D other)
        {
            GameManager.gameManager.currentGameState = GameManager.GameState.GameOver;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "ScoreArea");
            {
                Debug.Log("Score +1");
            }

        }
    }
