﻿using Settings;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound {

    public class BackgroundSound : MonoBehaviour {

        public AudioClip clipBeginning, clipEndless;
        public AudioMixerGroup mixerGroup;
        public float fadeValue = 1;
        public float pitch = 1;
        private AudioSource source;
        private Options options;

        void Start() {
            options = OptionsController.instance.options;
            source = gameObject.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = mixerGroup;
            source.volume = options.musicVolume * options.masterVolume;
            source.pitch = pitch;
            AudioUtils.SetAudioSource(source);
            if (clipBeginning != null) {
                source.clip = clipBeginning;
                source.Play();
            }
        }

        void Update() {
            source.volume = options.musicVolume * options.masterVolume * fadeValue;

            if (!source.isPlaying) {
                source.clip = clipEndless;
                source.loop = true;
                source.Play();
            }
        }
    }
}