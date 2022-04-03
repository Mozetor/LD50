using UnityEngine;
using UnityEngine.VFX;

namespace LD50.Player
{
    public class PlayerSmokeEffect : MonoBehaviour
    {
        public VisualEffect[] effects;

        public void SetSmokeSpawnRateFactor(float newFactor)
        {
            foreach (var effect in effects)
            {
                effect.SetFloat("_SpawnRateFactor", newFactor);
            }
        }
    }
}
