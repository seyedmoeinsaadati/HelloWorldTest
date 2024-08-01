using UnityEngine;

namespace FlipFlop
{
    public class AudioEventHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip uiClickSound;
        [SerializeField] private AudioClip cardFlipBack;
        [SerializeField] private AudioClip cardFlipUp;
        [SerializeField] private AudioClip guessCorrect;

        private void Awake()
        {
            instance = this;
        }

        ///////////////////////////////////////
        /// STATIC MEMEBERS
        ///////////////////////////////////////

        // singleton pattern
        private static AudioEventHandler instance;

        public static void PlayCardFlipUp()
        {
            if (instance == null) return;

            instance.audioSource.PlayOneShot(instance.cardFlipUp);
        }

        public static void PlayCardFlipBack()
        {
            if (instance == null) return;

            instance.audioSource.PlayOneShot(instance.cardFlipBack);
        }

        public static void PlayCorrectGuess()
        {
            if (instance == null) return;

            instance.audioSource.PlayOneShot(instance.guessCorrect);
        }

        public static void PlayUiClick()
        {
            if (instance == null) return;

            instance.audioSource.PlayOneShot(instance.uiClickSound);
        }
    }
}