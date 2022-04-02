using UnityEngine;

namespace LD50 {
    public class Iceberg : MonoBehaviour {

        public float speed;
        public float despawnZ;

        private void Update() {
            this.transform.position = this.transform.position - speed * Vector3.forward * Time.deltaTime;

            if (this.transform.position.z < despawnZ)
            {
                FindObjectOfType<GameManager>().roundStats.icebergsDodged++;
                Destroy(this.gameObject);
            }
        }
    }
}
