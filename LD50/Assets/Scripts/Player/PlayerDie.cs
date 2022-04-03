using LD50.Sound;
using LD50.Utils;
using UnityEngine;

namespace LD50.Player
{
    public class PlayerDie : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(!this.enabled || !collision.transform.CompareTag("Iceberg")) return;
            var g = FindObjectOfType<GameManager>();
            g.isAlive = false;
            g.AddRoundToGlobalStats();
            FindObjectOfType<SfxSoundPlayer>().PlaySfx(SfxSoundPlayer.FailSound);
            FindObjectOfType<SceneController>().ChangeScene("GameOver");
        }
    }
}
