using LD50.Icebergs;
using LD50.PowerUp;
using LD50.Utils;
using UnityEngine;

namespace LD50.Player {
    public class PlayerDie : MonoBehaviour {
        public int lives;

        private void OnCollisionEnter(Collision collision) {
            if (!this.enabled || !collision.transform.CompareTag("Iceberg")) return;

            lives--;
            if (lives == 0) {
                var g = FindObjectOfType<GameManager>();
                g.isAlive = false;
                g.AddRoundToGlobalStats();
                FindObjectOfType<SceneController>().ChangeScene("GameOver");
            } else {
                var p = FindObjectOfType<PowerUpManager>();
                p.RemovePowerUp(IcebergPreset.ElementType.ARMOUR_PLATING);
                var berg = collision.gameObject.GetComponent<Iceberg>();
                berg.Destroy();
            }
        }
    }
}
