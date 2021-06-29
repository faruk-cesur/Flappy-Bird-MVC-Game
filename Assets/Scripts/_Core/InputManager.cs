using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Input değerlerini kuşa aktarmak için instance oluşturuyoruz.
    public PlayerView.PlayerView playerView;
    
    private void Update()
    {
        // Her tıklandığında kuş zıplar
        if (Input.GetMouseButtonDown(0))
        {
            playerView.Jump();
        }
    }
}