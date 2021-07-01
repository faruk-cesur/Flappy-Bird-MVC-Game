using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
   private float moveSpeed = 2f;

   private void Start()
   {
      Destroy(gameObject,4f);
   }

   private void FixedUpdate()
   {
      MoveObstacle();
   }

   private void MoveObstacle()
   {
      transform.position += Vector3.left * moveSpeed * Time.deltaTime;
   }
}
