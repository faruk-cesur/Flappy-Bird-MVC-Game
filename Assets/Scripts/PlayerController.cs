using System;
using UnityEngine;

// (MVC) - View  Burada tutuluyor.

    public class PlayerController : MonoBehaviour
    {
        public Score _score;
        public Rigidbody2D rb;
        private float jumpPower;
        
        private void Start()
        {
            jumpPower = 5f;
            rb = GetComponent<Rigidbody2D>();
            Time.timeScale = 1;
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
    
    
    
    }
