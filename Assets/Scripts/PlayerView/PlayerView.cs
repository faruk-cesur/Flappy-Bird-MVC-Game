using System;
using UnityEngine;
using _Core;

// (MVC) - View  Burada tutuluyor.
namespace PlayerView
{
    public class PlayerView : MonoBehaviour
    {
        public GameObject bird;
        private float jumpSpeed = 5f;
        private Rigidbody2D rb;
        public GameObject prepare;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            switch (GameManager.gameManager.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    prepare.gameObject.SetActive(true);
                    break;
                case GameManager.GameState.MainGame:
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                    prepare.gameObject.SetActive(false);
                    break;
                case GameManager.GameState.FinishGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
        
        }

        public void Jump()
        {
            rb.velocity = Vector2.up * jumpSpeed;
       
        
        }
    
    
    
    }

}

