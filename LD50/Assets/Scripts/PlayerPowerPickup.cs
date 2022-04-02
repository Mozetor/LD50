using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD50 {
    public class PlayerPowerPickup : MonoBehaviour {

        private void OnCollisionEnter(Collision collision) {
            if (!collision.transform.CompareTag("PowerUp")) return;
            Debug.LogFormat("Power up {0}", collision.gameObject.GetComponent<PowerUp>().type);
            Destroy(collision.gameObject);
        }
    }
}
