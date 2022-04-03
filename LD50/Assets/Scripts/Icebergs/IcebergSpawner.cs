using LD50.PowerUp;
using System.Collections.Generic;
using UnityEngine;

namespace LD50.Icebergs {

    public class IcebergSpawner : MonoBehaviour {

        public List<IcebergPreset> presets;
        public List<Iceberg> icebergs;
        public float spawnZ;

        public CollectiblePowerUp fullSteamAheadPrefab;
        public CollectiblePowerUp armourPlatingPrefab;
        public CollectiblePowerUp maneuverabiltyUpPrefab;

        private float _cooldown;
        private GameManager _manager;

        private void Start() {
            _manager = FindObjectOfType<GameManager>();
        }

        private void Update() {
            if (_cooldown > 0) {
                _cooldown -= Time.deltaTime * _manager.speed;
                return;
            }

            var preset = presets[Random.Range(0, presets.Count)];
            foreach (var berg in preset.positions) {
                var position = new Vector3(_manager.GetLaneXPosition(berg.lane), 0, spawnZ + berg.offset * preset.width);
                switch (berg.type) {
                    case IcebergPreset.ElementType.ICEBERG:
                        var rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
                        Instantiate(icebergs[Random.Range(0, icebergs.Count)], position, rotation, this.transform);
                        break;
                    case IcebergPreset.ElementType.FULL_STEAM_AHEAD:
                        var fullSteamAhead = Instantiate(fullSteamAheadPrefab, position, Quaternion.identity, this.transform);
                        fullSteamAhead.type = berg.type;
                        break;
                    case IcebergPreset.ElementType.ARMOUR_PLATING:
                        var armourPlating = Instantiate(armourPlatingPrefab, position, Quaternion.identity, this.transform);
                        armourPlating.type = berg.type;
                        break;
                    case IcebergPreset.ElementType.MANEUVERABILITY:
                        var maneuverabilityUp = Instantiate(maneuverabiltyUpPrefab, position, Quaternion.identity, this.transform);
                        maneuverabilityUp.type = berg.type;
                        break;
                }
            }
            _cooldown = preset.width;
        }
    }
}
