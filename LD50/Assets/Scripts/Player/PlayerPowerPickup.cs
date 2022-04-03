using LD50.PowerUp;
using UnityEngine;

namespace LD50.Player {
    public class PlayerPowerPickup : MonoBehaviour {

        private PowerUpManager _manager;

        private void Start() {
            _manager = FindObjectOfType<PowerUpManager>();            
        }

        private void OnCollisionEnter(Collision collision) {
            if (!collision.transform.CompareTag("PowerUp")) return;

            var powerUp = collision.gameObject.GetComponent<CollectiblePowerUp>();
            _manager.TriggerPowerUp(powerUp.type);

            Destroy(collision.gameObject);
        }
    }
}
