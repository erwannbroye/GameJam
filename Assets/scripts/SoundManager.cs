using UnityEngine;
using System.Collections;

    public class SoundManager : MonoBehaviour 
    {
        [HeaderAttribute("File Settings :")]
        public AudioSource efxSource;
        public AudioSource musicSource;
        public static SoundManager instance = null;



        [HeaderAttribute("Sound Settings :")] 
        public float minVolumeRange = .85f;
        public float maxVolumeRange = 1f;

        void Start ()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            DontDestroyOnLoad (gameObject);
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play ();
        }

        public void PlaySfx(AudioClip clip)
        {
            efxSource.clip = clip;
            efxSource.Play ();
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