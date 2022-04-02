using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD50 {

    public class IcebergSpawner : MonoBehaviour {

        public List<IcebergPreset> presets;
        public List<Iceberg> icebergs;
        public float spawnZ;
        public float speed;

        public PowerUp fullSteamAheadPrefab;
        public PowerUp armourPlatingPrefab;
        public PowerUp maneuverabiltyUpPrefab;

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
                switch (berg.type) {
                    case IcebergPreset.ElementType.ICEBERG:
                        var rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
                        var iceberg = Instantiate(icebergs[Random.Range(0, icebergs.Count)], position, rotation, this.transform);
                        iceberg.speed = this.speed;
                        break;
                    case IcebergPreset.ElementType.FULL_STEAM_AHEAD:
                        var fullSteamAhead = Instantiate(fullSteamAheadPrefab, position, Quaternion.identity, this.transform);
                        fullSteamAhead.speed = this.speed;
                        fullSteamAhead.type = berg.type;
                        break;
                    case IcebergPreset.ElementType.ARMOUR_PLATING:
                        var armourPlating = Instantiate(armourPlatingPrefab, position, Quaternion.identity, this.transform);
                        armourPlating.speed = this.speed;
                        armourPlating.type = berg.type;
                        break;
                    case IcebergPreset.ElementType.MANEUVERABILITY:
                        var maneuverabilityUp = Instantiate(maneuverabiltyUpPrefab, position, Quaternion.identity, this.transform);
                        maneuverabilityUp.speed = this.speed;
                        maneuverabilityUp.type = berg.type;
                        break;
                }
            }
            _cooldown = preset.width / speed;
        }
    }
}
