using UnityEngine;

namespace LD50
{
    public class PlayerController : MonoBehaviour
    {
        private int _laneCount;
        private int _xDistanceBetweenLane;
        public Transform playerTransform;

        private void Awake()
        {
            var gameManager = FindObjectOfType<GameManager>();
            _laneCount = gameManager.laneCount;
            _xDistanceBetweenLane = gameManager.xDistanceBetweenLane;
        }

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
            var maxX = _laneCount / 2 * _xDistanceBetweenLane;
            var pos = playerTransform.position;
            pos.x += _xDistanceBetweenLane * direction;
            pos.x = Mathf.Max(Mathf.Min(pos.x, maxX), -maxX);
            playerTransform.position = pos;
        }
    }
}