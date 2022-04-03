using UnityEngine;

namespace LD50.Sound
{
    public class SfxSoundPlayer : MonoBehaviour
    {
        public const int PickupSound = 0;
        public const int UiSound = 1;
        public const int FailSound = 2;

        public AudioClipPlayer[] audioClipPlayers;

        public void PlaySfx(int soundIndex)
        {
            audioClipPlayers[soundIndex].Play();
        }
    }
}
