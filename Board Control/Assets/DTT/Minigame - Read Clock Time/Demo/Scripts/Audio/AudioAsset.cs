using UnityEngine;

namespace DTT.MiniGame.WhatsTheTime.Demo
{
    ///<summary>
    /// Holds audio files.
    ///</summary>
    [CreateAssetMenu(fileName = "AudioAsset", menuName = "DTT/MiniGame/WhatsTheTime/AudioAsset")]
    public class AudioAsset : ScriptableObject
    {
        /// <summary>
        /// Used for scaling audio down.
        /// </summary>
        [SerializeField]
        [Range(0, 1)]
        [Tooltip("This can be used to turn down non-music audio if it's too loud")]
        private float volume = 1f;

        /// <summary>
        /// Get and Set for volume.
        /// </summary>
        public float Volume
        {
            get => volume;
            set => volume = Mathf.Clamp01(value); 
        }

        /// <summary>
        /// The audio clip.
        /// </summary>
        [SerializeField]
        private AudioClip _audioClip;

        /// <summary>
        /// Getter for the audio clip.
        /// </summary>
        public AudioClip AudioClip => _audioClip;
    }
}
