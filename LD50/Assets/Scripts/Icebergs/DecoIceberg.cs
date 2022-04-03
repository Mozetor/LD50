using UnityEngine;

namespace LD50.Icebergs
{
    public class DecoIceberg : MonoBehaviour
    {
        public float teleportZ;
        
        private Vector3 _teleportOffset;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _teleportOffset = Vector3.forward * 2 * teleportZ;
        }

        private void Update()
        {
            transform.position -= _gameManager.speed * Time.deltaTime * Vector3.forward;
            if (transform.position.z < -teleportZ)
                transform.position += _teleportOffset;
        }
    }
}
