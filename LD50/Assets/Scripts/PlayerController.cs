using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD50
{
    public class PlayerController : MonoBehaviour
    {
        public int laneCount = 3;
        public int xDistanceBetweenLane = 5;
        public Transform playerTransform;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMove(1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                TryMove(-1);
            }
        }

        private void TryMove(int direction)
        {
            var max = laneCount / 2 * xDistanceBetweenLane;
            var pos = playerTransform.position;
            pos.x += xDistanceBetweenLane * direction;
            // Mathf.
            //
            // playerTransform.position = pos;
            
        }
    }
}