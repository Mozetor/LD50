using LD50.Settings;
using UnityEngine;
using UnityEngine.Audio;

namespace LD50.Sound {

    public class AudioClipPlayer : MonoBehaviour {
        public AudioMixerGroup mixerGroup;
        public AudioClip clip;
        public bool autoStart;

        private AudioSource source;

        void Start() {
            source = gameObject.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = mixerGroup;
            source.volume = OptionsController.instance.options.sfxVolume * OptionsController.instance.options.masterVolume;
            source.loop = false;
            AudioUtils.SetAudioSource(source);
            source.clip = clip;
            if(autoStart) source.Play();
        }

        private void Update() {
            if (!source.isPlaying) {
                Destroy(this);
            }
        }

        public void Play()
        {
            source.volume = OptionsController.instance.options.sfxVolume * OptionsController.instance.options.masterVolume;
            source.Play();
        }
    }
}