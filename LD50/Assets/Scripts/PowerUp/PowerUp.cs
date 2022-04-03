using LD50.Icebergs;
using LD50.Player;
using System;
using System.Collections;
using UnityEngine;

namespace LD50.PowerUp {
    public interface IPowerUp {

        static readonly IPowerUp fullSteamAhead = new FullSteamAhead();
        static readonly IPowerUp maneuverabilityUp = new ManeuverabilityUp();
        static readonly IPowerUp armourPlating = new ArmourPlating();

        void TriggerPowerUp();

        private class FullSteamAhead : IPowerUp {

            private const float DURATION = 6f;
            private const int SPEED_FACTOR = 3;

            public void TriggerPowerUp() {
                var obj = GameObject.FindObjectOfType<PowerUpManager>();
                obj.StartCoroutine(ExecutePowerUp(obj).GetEnumerator());
            }

            private IEnumerable ExecutePowerUp(PowerUpManager powerUpManager) {
                var playerDie = GameObject.FindObjectOfType<PlayerDie>();
                var playerDestroy = GameObject.FindObjectOfType<PlayerDestroyIceberg>();
                var manager = GameObject.FindObjectOfType<GameManager>();

                if(powerUpManager.activePowerUps[this] == 0) { 
                    playerDie.enabled = false;
                    playerDestroy.enabled = true;
                    manager.SetSpeed(manager.speed * SPEED_FACTOR);
                }

                yield return new WaitForSeconds(DURATION);

                powerUpManager.RemovePowerUp(IcebergPreset.ElementType.FULL_STEAM_AHEAD);
                if (powerUpManager.activePowerUps[this] == 0) {
                    playerDie.enabled = true;
                    playerDestroy.enabled = false;
                    manager.SetSpeed(manager.speed / SPEED_FACTOR);
                }
            }
        }

        private class ManeuverabilityUp : IPowerUp {
            public void TriggerPowerUp() {
                throw new NotImplementedException();
            }
        }

        private class ArmourPlating : IPowerUp {
            public void TriggerPowerUp() {
                throw new NotImplementedException();
            }
        }
    }
}
