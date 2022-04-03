using LD50.Icebergs;
using LD50.Utils;
using UnityEngine;

namespace LD50.Player {
    public class PlayerDestroyIceberg : MonoBehaviour {

        private void Awake() {
            enabled = false;
        }

        private void OnCollisionEnter(Collision collision) {
            if (!this.enabled || !collision.transform.CompareTag("Iceberg")) return;
            var g = collision.gameObject.GetComponent<Iceberg>();
            g.Destroy();
        }
    }
}
