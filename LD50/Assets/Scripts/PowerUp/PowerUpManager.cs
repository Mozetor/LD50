using LD50.Icebergs;
using System;
using System.Collections.Generic;
using LD50.Sound;
using UnityEngine;

namespace LD50.PowerUp {

    public class PowerUpManager : MonoBehaviour {

        public readonly Dictionary<IPowerUp, int> activePowerUps = new Dictionary<IPowerUp, int>() { 
            [IPowerUp.fullSteamAhead] = 0,
            [IPowerUp.armourPlating] = 0,
            [IPowerUp.maneuverabilityUp] = 0
        };

        public void TriggerPowerUp(IcebergPreset.ElementType type) {
            var powerUp = type switch {
                IcebergPreset.ElementType.FULL_STEAM_AHEAD => IPowerUp.fullSteamAhead,
                IcebergPreset.ElementType.ARMOUR_PLATING => IPowerUp.armourPlating,
                IcebergPreset.ElementType.MANEUVERABILITY => IPowerUp.maneuverabilityUp,
                _ => throw new ArgumentException($"Unknown power up type {type}")
            };
            powerUp.TriggerPowerUp();
            FindObjectOfType<SfxSoundPlayer>().PlaySfx(SfxSoundPlayer.PickupSound);
            FindObjectOfType<GameManager>().roundStats.powerUpsCollected++;
            activePowerUps[powerUp]++;
        }

        public void RemovePowerUp(IcebergPreset.ElementType type) {
            var powerUp = type switch {
                IcebergPreset.ElementType.FULL_STEAM_AHEAD => IPowerUp.fullSteamAhead,
                IcebergPreset.ElementType.ARMOUR_PLATING => IPowerUp.armourPlating,
                IcebergPreset.ElementType.MANEUVERABILITY => IPowerUp.maneuverabilityUp,
                _ => throw new ArgumentException($"Unknown power up type {type}")
            };
            powerUp.CleanUpPowerUp();
            activePowerUps[powerUp]--;
        }
    }
}
