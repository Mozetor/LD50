using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace LD50 {
    public class DayNightCycle : MonoBehaviour {
        public Light sun;
        public List<Light> nightLights;
        public float time;
        public float timeFactor;

        private List<float> maxIntensities;

        private void Start() {
            maxIntensities = nightLights.Select(l => l.intensity).ToList();
        }

        private void Update() {
            time += Time.deltaTime / timeFactor;
            time %= 2;

            sun.intensity = time > 1 ? 0 : 1;

            sun.transform.rotation = Quaternion.Euler(time * 180, -30, 0);

            var intensityFactor = Mathf.SmoothStep(0, 1, Mathf.Sin((time - 1)/ 2 * Mathf.PI));

            foreach (var (light, maxIntensity) in nightLights.Zip(maxIntensities, (a, b) => (a, b))) {
                light.intensity = maxIntensity * intensityFactor;
            }
        }

    }
}
