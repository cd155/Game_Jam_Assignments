using System.Collections.Generic;
using UnityEngine;
using DTT.MiniGame.WhatsTheTime.Runtime;

namespace DTT.MiniGame.WhatsTheTime.Demo
{
    ///<summary>
    /// Holds and plays audio assets.
    ///</summary>
    public class AudioManager : MonoBehaviour
    {
        /// <summary>
        /// The different audio objects that can be played.
        /// </summary>
        public enum GameSfx
        {
            /// <summary>
            /// Audio asset for when a UI button is pressed.
            /// </summary>
            [InspectorName("Button Click")]
            UI_BUTTON_CLICK = 0,

            /// <summary>
            /// Audio asset for when a clock button is pressed.
            /// </summary>
            [InspectorName("Clock Button")]
            CLOCK_BUTTON = 1,

            /// <summary>
            /// Audio asset for when a the correct answer is selected.
            /// </summary>
            [InspectorName("Correct Answer")]
            CORRECT_ANSWER = 2,

            /// <summary>
            /// Audio asset for when a the wrong answers is selected.
            /// </summary>
            [InspectorName("Card Match")]
            INCORRECT_ANSWER = 3,
        }

        /// <summary>
        /// The audio source used to play the clips.
        /// </summary>
        [SerializeField]
        [Tooltip("The audio source used to play")]
        private AudioSource _audioSource;

        /// <summary>
        /// This list contains all the clips we will play.
        /// </summary>
        [SerializeField]
        [Tooltip("The audio clips we wish to play in app")]
        private List<AudioAsset> _clips;

        /// <summary>
        /// A set of dictionaries allowing quick look up of the correct clip by its enum.
        /// </summary>
        private readonly Dictionary<GameSfx, AudioAsset> _sfxClipPairs = new Dictionary<GameSfx, AudioAsset>();

        /// <summary>
        /// Creates the dictionary to play audio through.
        /// </summary>
        private void Awake() => PopulateGameClips();

        /// <summary>
        /// Plays an audio clip.
        /// </summary>
        /// <param name="clip">The clip to play.</param>
        /// <param name="volumeScale">The volume for the clip (0 to 1).</param>
        public void PlayAudioClip(GameSfx clip) => _audioSource.PlayOneShot(_sfxClipPairs[clip].AudioClip, _sfxClipPairs[clip].Volume);

        /// <summary>
        /// Creates dictionary entries for quick lookup of sound effects by enum.
        /// </summary>
        private void PopulateGameClips()
        {
            _sfxClipPairs.Clear();
            for (int i = 0; i < _clips.Count; i++)
                _sfxClipPairs.Add((GameSfx)i, _clips[i]);
        }
    }
}
