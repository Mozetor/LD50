using LD50.Icebergs;
using UnityEngine;

namespace LD50 {
    public class PowerUp : MonoBehaviour {

        public float despawnZ;
        [HideInInspector]
        public IcebergPreset.ElementType type;
        private GameManager _gameManager;
        
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update() {
            this.transform.position -= _gameManager.speed * Time.deltaTime * Vector3.forward;

            if (this.transform.position.z < despawnZ) {
                Destroy(this.gameObject);
            }
        }
    }
}
