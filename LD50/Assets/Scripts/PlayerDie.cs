using LD50.Utils;
using UnityEngine;

namespace LD50
{
    public class PlayerDie : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(!collision.transform.CompareTag("Iceberg")) return;
            
            FindObjectOfType<GameManager>().AddRoundToGlobalStats();
            FindObjectOfType<SceneController>().ChangeScene("GameOver");
        }
    }
}
