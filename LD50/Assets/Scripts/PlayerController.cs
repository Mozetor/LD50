using UnityEngine;

namespace LD50
{
    public class PlayerController : MonoBehaviour
    {
        public Transform playerTransform;
        public float maneuverability;
        private int _lane;
        private GameManager _gameManager;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _rigidbody = FindObjectOfType<Rigidbody>();
        }

        private void Update()
        {
            var laneDiff = 0;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                laneDiff--;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                laneDiff++;
            }

            _lane = Mathf.Clamp(_lane + laneDiff, 0, _gameManager.laneCount - 1);
        }

        private void FixedUpdate() {
            
            _rigidbody.MovePosition(Vector3.Lerp(
                this.transform.position, 
                Vector3.right * _gameManager.GetLaneXPosition(_lane), 
                Time.fixedDeltaTime * maneuverability)
           );
        }
    }
}