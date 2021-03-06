using UnityEngine;

namespace LD50.Player {
    public class PlayerController : MonoBehaviour {
        public float maneuverability;
        public float laneSwapThreshold;
        private int _lane;
        private GameManager _gameManager;
        private Rigidbody _rigidbody;

        private void Awake() {
            _gameManager = FindObjectOfType<GameManager>();
            _rigidbody = FindObjectOfType<Rigidbody>();
            _lane = _gameManager.laneCount / 2;
        }

        private void Update() {
            var laneDiff = 0;

            if (Mathf.Abs(transform.position.x - _gameManager.GetLaneXPosition(_lane)) < laneSwapThreshold &&
                (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ) {
                laneDiff--;
            }
            if (Mathf.Abs(transform.position.x - _gameManager.GetLaneXPosition(_lane)) < laneSwapThreshold &&
                (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ) {
                laneDiff++;
            }

            _lane = Mathf.Clamp(_lane + laneDiff, 0, _gameManager.laneCount - 1);
        }

        private void FixedUpdate() {
            var distance = (_gameManager.GetLaneXPosition(_lane) - transform.position.x) /
                (_gameManager.xDistanceBetweenLane + 0.1f);


            var distanceToEase = 0.9f * (1 - Mathf.Abs(distance)) + 0.1f;

            var distanceToAngleTime = 0.5f * Mathf.Sin(distance * Mathf.PI) + 0.5f;


            _rigidbody.MoveRotation(Quaternion.Lerp(
                Quaternion.Euler(0, -20, 0),
                Quaternion.Euler(0, 20, 0),
                distanceToAngleTime
            ));

            _rigidbody.MovePosition(
                Vector3.Lerp(
                    new Vector3(transform.position.x,0, -8),
                    new Vector3(_gameManager.GetLaneXPosition(_lane),0, -8),
                    Time.fixedDeltaTime * (maneuverability + _gameManager.difficultyIncrease) * distanceToEase
                )
           );
        }
    }
}