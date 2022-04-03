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
        void CleanUpPowerUp();

        private class FullSteamAhead : IPowerUp {

            private const float DURATION = 6f;
            private const int SPEED_FACTOR = 3;

            public void TriggerPowerUp() {
                var obj = GameObject.FindObjectOfType<PowerUpManager>();
                obj.StartCoroutine(ExecutePowerUp(obj).GetEnumerator());
            }

            public void CleanUpPowerUp() { 
                // nothing to do here
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

            private const int MANEUVERABILITY_FACTOR = 2;
            private const float DURATION = 15;

            public void TriggerPowerUp() {
                var obj = GameObject.FindObjectOfType<PowerUpManager>();
                obj.StartCoroutine(ExecutePowerUp(obj).GetEnumerator());
            }
            public void CleanUpPowerUp() {
                // nothing to do here
            }


            private IEnumerable ExecutePowerUp(PowerUpManager powerUpManager) {
                var player = GameObject.FindObjectOfType<PlayerController>();

                if (powerUpManager.activePowerUps[this] == 0) {
                    player.maneuverability *= MANEUVERABILITY_FACTOR;
                }

                yield return new WaitForSeconds(DURATION);

                powerUpManager.RemovePowerUp(IcebergPreset.ElementType.MANEUVERABILITY);
                if (powerUpManager.activePowerUps[this] == 0) {
                    player.maneuverability /= MANEUVERABILITY_FACTOR;
                }
            }
        }

        private class ArmourPlating : IPowerUp {
            public void TriggerPowerUp() {
                var playerDie = GameObject.FindObjectOfType<PlayerDie>();
                playerDie.lives++;
                var plating = GameObject.Find("Plating").GetComponent<MeshRenderer>();
                plating.enabled = true;
            }
            public void CleanUpPowerUp() {
                var obj = GameObject.FindObjectOfType<PowerUpManager>();
                if (obj.activePowerUps[this] == 1) {
                    var plating = GameObject.Find("Plating").GetComponent<MeshRenderer>();
                    plating.enabled = false;
                }
            }

        }
    }
}
