using LD50.Utils;
using UnityEngine;

namespace LD50
{
    public class PlayerDie : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(!collision.transform.CompareTag("Iceberg")) return;
            var g = FindObjectOfType<GameManager>();
            g.isAlive = false;
            g.AddRoundToGlobalStats();
            FindObjectOfType<SceneController>().ChangeScene("GameOver");
        }
    }
}
