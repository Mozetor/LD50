using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD50 {

    public class IcebergSpawner : MonoBehaviour {

        public List<IcebergPreset> presets;
        public List<Iceberg> icebergs;
        public float spawnZ;
        public float speed;

        private float _cooldown;
        private GameManager _manager;

        private void Start() {
            _manager = FindObjectOfType<GameManager>();
        }

        private void Update() {
            if (_cooldown > 0) {
                _cooldown -= Time.deltaTime;
                return;
            }

            var preset = presets[Random.Range(0, presets.Count)];
            foreach (var berg in preset.positions) {
                var position = new Vector3(_manager.GetLaneXPosition(berg.lane), 0, spawnZ + berg.offset * preset.width);
                var rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
                var iceberg = Instantiate(icebergs[Random.Range(0, icebergs.Count)], position, rotation, this.transform);
                iceberg.speed = this.speed;
            }
            _cooldown = preset.width / speed;
        }
    }
}
