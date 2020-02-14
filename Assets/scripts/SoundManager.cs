using UnityEngine;
using System.Collections;

    public class SoundManager : MonoBehaviour 
    {
        [HeaderAttribute("File Settings :")]
        public AudioSource efxSource;
        public AudioSource musicSource;
        public AudioClip [] efxClips;
        public AudioClip [] musicClips;
        public int musicNum;
        public int efxNum;
        public static SoundManager instance = null;



        [HeaderAttribute("Sound Settings :")] 
        public float minVolumeRange = .85f;
        public float maxVolumeRange = 1f;

        void Start ()
        {
            if (instance == null)
                instance = this;
            DontDestroyOnLoad (gameObject);
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.PlayOneShot (clip, 1f);
        }

        public void PlaySfx(int i)
        {
            efxSource.PlayOneShot (efxClips[i], 1f);
        }


        public void RandomSfx(params AudioClip[] clips)
        {
            int index = Random.Range(0, clips.Length);
            float randomVolume = Random.Range(minVolumeRange, maxVolumeRange);

            efxSource.volume = randomVolume;
            efxSource.clip = clips[index];
            efxSource.Play();
        }
    }