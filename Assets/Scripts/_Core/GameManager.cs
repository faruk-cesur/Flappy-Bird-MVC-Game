using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        public enum GameState
        {
            Prepare,
            MainGame,
            FinishGame,
        }

        public PlayerView.PlayerView player;
        private GameState currentGameState;

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
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                currentGameState = value;
            }

        }

        private void Awake()
        {
            gameManager = this;
            
        }

        private void Update()
        {
            switch (CurrentGameState)
            {
                case GameState.Prepare:
                    CurrentGameState = GameState.Prepare;
                    if (Input.GetMouseButtonDown(0))
                    {
                        CurrentGameState = GameState.MainGame;
                    }
                    break;
                case GameState.MainGame:
                    break;
                case GameState.FinishGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
