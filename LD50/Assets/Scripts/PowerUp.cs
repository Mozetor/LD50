using UnityEngine;

namespace LD50 {
    public class PowerUp : MonoBehaviour {

        public float despawnZ;
        [HideInInspector]
        public float speed;
        [HideInInspector]
        public IcebergPreset.ElementType type;

        private void Update() {
            this.transform.position = this.transform.position - speed * Vector3.forward * Time.deltaTime;

            if (this.transform.position.z < despawnZ) {
                Destroy(this.gameObject);
            }
        }
    }
}
