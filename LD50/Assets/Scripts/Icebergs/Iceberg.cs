using UnityEngine;

namespace LD50.Icebergs {
    public class Iceberg : MonoBehaviour {

        public float despawnZ;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update() {
            this.transform.position -= _gameManager.speed * Time.deltaTime * Vector3.forward;

            if (this.transform.position.z < despawnZ)
            {
                FindObjectOfType<GameManager>().IcebergDodged();
                Destroy(this.gameObject);
            }
        }

        public void Destroy() {
            // vfx
            Destroy(this.gameObject);
        }
    }
}
