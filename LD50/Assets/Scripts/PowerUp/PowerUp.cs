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
                var controller = GameObject.Find("FullSteamAhead").GetComponent<Animator>();
                controller.transform.GetChild(0).gameObject.SetActive(true);
                controller.SetTrigger("Trigger");
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
                    controller.transform.GetChild(0).gameObject.SetActive(false);
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
                var controller = GameObject.Find("Maneuverability").GetComponent<Animator>();
                controller.transform.GetChild(0).gameObject.SetActive(true);
                controller.SetTrigger("Trigger");

                if (powerUpManager.activePowerUps[this] == 0) {
                    player.maneuverability *= MANEUVERABILITY_FACTOR;
                }

                yield return new WaitForSeconds(DURATION);

                powerUpManager.RemovePowerUp(IcebergPreset.ElementType.MANEUVERABILITY);
                if (powerUpManager.activePowerUps[this] == 0) {
                    player.maneuverability /= MANEUVERABILITY_FACTOR;
                    controller.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }

        private class ArmourPlating : IPowerUp {
            public void TriggerPowerUp() {
                var playerDie = GameObject.FindObjectOfType<PlayerDie>();
                playerDie.lives++;
                var plating = GameObject.Find("Plating").GetComponent<MeshRenderer>();
                plating.enabled = true;
                var obj = GameObject.FindObjectOfType<PowerUpManager>();
                GameObject.Find("Armour").transform.GetChild(0).gameObject.SetActive(true);
                var amount = GameObject.Find("Amount").GetComponent<TMPro.TextMeshProUGUI>();
                amount.text = $"{obj.activePowerUps[this] + 1}";
            }
            public void CleanUpPowerUp() {
                var obj = GameObject.FindObjectOfType<PowerUpManager>();
                var amount = GameObject.Find("Amount").GetComponent<TMPro.TextMeshProUGUI>();
                amount.text = $"{obj.activePowerUps[this] + 1}";
                if (obj.activePowerUps[this] == 1) {
                    var plating = GameObject.Find("Plating").GetComponent<MeshRenderer>();
                    plating.enabled = false;
                    GameObject.Find("ArmourPlating").SetActive(false);
                }
            }

        }
    }
}
