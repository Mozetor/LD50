using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD50 {
    public class DayNightCycle : MonoBehaviour {
        public Light sun;
        public List<Light> nightLights;
        public Image dayNightIndicator;
        public float time;
        public float timeFactor;

        private List<float> maxIntensities;

        private void Start() {
            maxIntensities = nightLights.Select(l => l.intensity).ToList();
        }

        private void Update() {
            time += Time.deltaTime / timeFactor;
            time %= 2;

            dayNightIndicator.rectTransform.rotation = Quaternion.Euler(0, 0, time * 180);

            sun.intensity = time > 1 ? 0 : Mathf.Sin(time * Mathf.PI);
            sun.transform.rotation = Quaternion.Euler(time * 180, -30, 0);

            var intensityFactor = Mathf.Pow(-1f / 2 * Mathf.Sin(time * Mathf.PI) + 1f / 2, 2);
            foreach (var (light, maxIntensity) in nightLights.Zip(maxIntensities, (a, b) => (a, b))) {
                light.intensity = maxIntensity * intensityFactor;
            }
        }

    }
}
