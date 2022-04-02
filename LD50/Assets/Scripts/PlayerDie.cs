using UnityEngine;

namespace LD50
{
    public class PlayerDie : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(!collision.transform.CompareTag("Iceberg")) return;
            
            Debug.Log("Game over!");
        }
    }
}
