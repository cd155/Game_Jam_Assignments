using UnityEngine;
using DTT.MiniGame.WhatsTheTime.Runtime;
using UnityEngine.UI;

namespace DTT.MiniGame.WhatsTheTime.Demo
{
    /// <summary>
    /// Handles the UI of the game.
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        /// <summary>
        /// Reference to the game UI of this scene.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the game UI of this scene")]
        private WhatsTheTimeManager _manager;

        /// <summary>
        /// Reference to the game controller of this scene.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the game controller of this scene")]
        private GameController _gameController;

        /// <summary>
        /// Reference to the audio manager of this scene.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the audio manager of this scene")]
        private AudioManager _audioManager;

        /// <summary>
        /// Reference to the play button.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the play button")]
        private PlayButton _playButton;

        /// <summary>
        /// Reference to the restart button.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the restart button")]
        private RestartButton _restartButton;

        /// <summary>
        /// Reference to the pause button.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the pause button")]
        private PauseButton _pauseButton;

        /// <summary>
        /// The level text of the "level-sign".
        /// </summary>
        [SerializeField]
        [Tooltip("The level text of the level-sign")]
        private Text _levelText;

        /// <summary>
        /// On enable subscribe to button events.
        /// </summary>
        private void OnEnable()
        {
            _pauseButton.PauseButtonPressed += TogglePaused;
            _restartButton.RestartButtonPressed += RestartGameLevel;
            _playButton.PlayButtonPressed += PlayNextLevel;
            _manager.LevelFinished += OnLevelFinish;
            _gameController.WrongButtonPressed += IncorrectButtonPressed;
            _gameController.AnswerButtonPressed += CorrectButtonPressed;
        }

        /// <summary>
        /// On disable unsubscribe to button events.
        /// </summary>
        private void OnDisable()
        {
            _pauseButton.PauseButtonPressed -= TogglePaused;
            _restartButton.RestartButtonPressed -= RestartGameLevel;
            _playButton.PlayButtonPressed -= PlayNextLevel;
            _manager.LevelFinished -= OnLevelFinish;
            _gameController.WrongButtonPressed -= IncorrectButtonPressed;
            _gameController.AnswerButtonPressed -= CorrectButtonPressed;
        }

        /// <summary>
        /// Update checks for player input to quit the game.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        /// <summary>
        /// Toggles the paused state of the game.
        /// </summary>
        /// <param name="paused">Whether or not the game has been paused.</param>
        private void TogglePaused(bool paused)
        {
            if (paused)
            {
                _manager.Pause();
                _restartButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                _manager.Continue();
                _restartButton.GetComponent<Button>().interactable = true;
            }

            _audioManager.PlayAudioClip(AudioManager.GameSfx.UI_BUTTON_CLICK);
        }

        /// <summary>
        /// Restarts the game level.
        /// </summary>
        private void RestartGameLevel() { 
            _manager.RestartLevel();
            _audioManager.PlayAudioClip(AudioManager.GameSfx.UI_BUTTON_CLICK);
        }

        /// <summary>
        /// Plays the next level of the game when the play button has been pressed.
        /// </summary>
        private void PlayNextLevel()
        {
            _manager.NextLevel();
            _audioManager.PlayAudioClip(AudioManager.GameSfx.UI_BUTTON_CLICK);
            TogglePlayButtonActive(false);
            _restartButton.GetComponent<Button>().interactable = true;
            _pauseButton.GetComponent<Button>().interactable = true;
            UpdateLevelText(_manager.CurrentLevel+1);
        }

        /// <summary>
        /// Sets the UI when the level has been finished.
        /// </summary>
        private void OnLevelFinish()
        {
            _restartButton.GetComponent<Button>().interactable = false;
            _pauseButton.GetComponent<Button>().interactable = false;
            TogglePlayButtonActive(true);
        }

        /// <summary>
        /// Toggles the play button active state.
        /// </summary>
        /// <param name="active">Whether or not it should be activated.</param>
        private void TogglePlayButtonActive(bool active) => _playButton.gameObject.SetActive(active);

        /// <summary>
        /// Plays the audio clip for when the incorrect button is pressed.
        /// </summary>
        private void IncorrectButtonPressed() => _audioManager.PlayAudioClip(AudioManager.GameSfx.INCORRECT_ANSWER);

        /// <summary>
        /// Plays the audio clip for when the correct button is pressed.
        /// </summary>
        private void CorrectButtonPressed() => _audioManager.PlayAudioClip(AudioManager.GameSfx.CORRECT_ANSWER);

        /// <summary>
        /// Updates the level-sign text.
        /// </summary>
        public void UpdateLevelText(int level) => _levelText.text = "Level " + level.ToString();
    }
}
