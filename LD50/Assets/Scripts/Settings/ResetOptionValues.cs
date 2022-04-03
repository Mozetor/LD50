using UnityEngine;

namespace LD50.Settings
{
    /// <summary>
    /// Accesses the OptionsController instance to reset setting values.
    /// </summary>
    public class ResetOptionValues : MonoBehaviour {
        /// <summary>
        /// Resets option values to default.
        /// </summary>
        public void ResetValues() {
            OptionsController.instance.ResetValues();
        }
    }
}
