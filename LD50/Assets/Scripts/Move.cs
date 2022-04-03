using UnityEngine;

namespace LD50
{
    public class Move : MonoBehaviour
    {
        public float movement = 0.25f;
        public float speed = 1f;

        private Vector3 _startPosition;
        private float _current;
        private int _dir = 1;

        private void Start()
        {
            _startPosition = transform.position;
            _current = Random.Range(0f, 1f);
        }

        private void Update()
        {
            _current += Time.deltaTime * _dir * speed;
            if (_current > 1 && _dir == 1 || _current < 0 && _dir == -1) _dir *= -1;
            transform.position = _startPosition + Mathf.Lerp(-movement, movement, _current) * Vector3.up;
        }
    }
}