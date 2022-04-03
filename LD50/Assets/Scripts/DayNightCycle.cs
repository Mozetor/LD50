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

        private List<float> _maxIntensities;
        private float _maxSunIntensity;

        private void Start() {
            _maxIntensities = nightLights.Select(l => l.intensity).ToList();
            _maxSunIntensity = sun.intensity;
        }

        private void Update() {
            time += Time.deltaTime / timeFactor;
            time %= 2;

            dayNightIndicator.rectTransform.rotation = Quaternion.Euler(0, 0, time * 180);

            sun.intensity = time > 1 ? 0 : Mathf.Sin(time * Mathf.PI) * _maxSunIntensity;
            sun.transform.rotation = Quaternion.Euler(time * 180, -30, 0);
            // Debug.Log($"sun:{sun.gameObject.name}={sun.intensity* _maxSunIntensity} (max:{_maxSunIntensity})");

            var intensityFactor = Mathf.Pow(-1f / 2 * Mathf.Sin(time * Mathf.PI) + 1f / 2, 2);
            foreach (var (light, maxIntensity) in nightLights.Zip(_maxIntensities, (a, b) => (a, b)))
            {
                light.intensity = maxIntensity * intensityFactor;
                // Debug.Log($"light:{light.gameObject.name}={maxIntensity*intensityFactor} (max:{maxIntensity})");
            }
        }

    }
}
