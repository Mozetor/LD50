using UnityEngine;

namespace LD50
{
    public class DecoIceberg : MonoBehaviour
    {
        private Vector3 _teleportOffset;
        private float _speed;
        public float teleportZ;
        

        private void Awake()
        {
            _speed = FindObjectOfType<IcebergSpawner>().speed;
            _teleportOffset = Vector3.forward * 2 * teleportZ;
        }

        private void Update()
        {
            transform.position -= _speed * Time.deltaTime * Vector3.forward;
            if (transform.position.z < -teleportZ)
                transform.position += _teleportOffset;
        }
    }
}
