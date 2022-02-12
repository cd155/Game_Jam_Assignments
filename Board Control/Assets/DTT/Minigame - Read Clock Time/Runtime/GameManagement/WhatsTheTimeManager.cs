using System;
using UnityEngine;
using DTT.MinigameBase;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
	///<summary>
	/// Manager class for the whats the time game.
	///</summary>
	[RequireComponent(typeof(GameController)), RequireComponent(typeof(TimeSpanGeneration))]
	public class WhatsTheTimeManager : MonoBehaviour, IMinigame<LevelSettings, WhatsTheTimeResult>
	{
		/// <summary>
		/// Should the game begin on start?.
		/// </summary>
		[SerializeField]
		[Tooltip("Should the game begin on start?")]
		private bool _playOnStart = true;

		/// <summary>
		/// Generator for the time spans of the minigame.
		/// </summary>
		private TimeSpanGeneration _timeSpanGenerator;

		/// <summary>
		/// Reference to the game controller.
		/// </summary>
		private GameController _gameController;

		/// <summary>
		/// The counter for what round we're on.
		/// </summary>
		private int _currentLevel = 0;

		/// <summary>
		/// Whether the game is paused or not.
		/// </summary>
		private bool _isPaused = false;

		/// <summary>
		/// Whether the game is active or not.
		/// </summary>
		private bool _isGameActive = false;

		/// <summary>
		/// Counter for the amount of wrong answers.
		/// </summary>
		private int _incorrectAnswersGiven;

		/// <summary>
		/// The timer for the entire game session.
		/// </summary>
		private float _timeElapsed;

		/// <summary>
		/// The counter for what round we're on.
		/// </summary>
		public int CurrentLevel => _currentLevel;

		/// <summary>
		/// Whether the game is paused or not.
		/// </summary>
		public bool IsPaused => _isPaused;

		/// <summary>
		/// Whether the game is active or not.
		/// </summary>
		public bool IsGameActive => _isGameActive;

		/// <summary>
		/// The action that will be fired when the game has started.
		/// </summary>
		public event Action Started;

		/// <summary>
		/// The action that will be fire when a level has been finished.
		/// </summary>
		public event Action LevelFinished;

		/// <summary>
		/// The action that will be fired when the game has finished.
		/// </summary>
		public event Action<WhatsTheTimeResult> Finish;

		/// <summary>
		/// Checks if game should play on start.
		/// </summary>
		private void Start()
		{
			if (_playOnStart)
				StartLevel();
		}

		/// <summary>
		/// Subscribes to events.
		/// </summary>
		private void OnEnable()
		{
			_gameController = GetComponent<GameController>();
			_gameController.GameEnded += FinishLevel;
			_gameController.WrongButtonPressed += OnWrongAnswer;
		}

		/// <summary>
		/// Subscribes to events.
		/// </summary>
		private void OnDisable()
		{
			_gameController.GameEnded -= FinishLevel;
			_gameController.WrongButtonPressed -= OnWrongAnswer;
		}

		/// <summary>
		/// Starts the game.
		/// </summary>
		public void StartGame(LevelSettings levelSettings)
		{
			Started.Invoke();
			_gameController.Clock.ClockTimer.ResetTimer();
			StartLevel();
		}

		/// <summary>
		/// Sets up the game with a specific level.
		/// </summary>
		private void StartLevel()
		{
			if (_currentLevel > _gameController.TotalLevels - 1)
				_currentLevel = 0;

			_gameController.GenerateGame(_currentLevel);
		}

		/// <summary>
		/// Restarts the level by etting up a new game with the same level.
		/// </summary>
		public void RestartLevel()
		{
			if (_gameController.Clock.CanBeReset) 
				StartLevel();
		}

		/// <summary>
		/// Proceeds to the next level.
		/// </summary>
		public void NextLevel()
		{
			_currentLevel++;
			StartLevel();
		}

		/// <summary>
		/// Pauses the game.
		/// </summary>
		public void Pause()
		{
			_isPaused = true;
			_gameController.Clock.PauseGame();
		}

		/// <summary>
		/// Continues the game.
		/// </summary>
		public void Continue()
		{
			_isPaused = false;
			_gameController.Clock.ContinueGame();
		}

		/// <summary>
		/// Ends the level by adding up the level counter.
		/// </summary>
		/// <param name="time">The time that it took to complete the level.</param>
		public void FinishLevel(float time)
		{
			_timeElapsed += time;
			_gameController.Clock.FinishedLevel();
			LevelFinished?.Invoke();
		}

		/// <summary>
		/// Forces the game to finish.
		/// </summary>
		public void ForceFinish()
		{
			_isGameActive = false;
			_isPaused = false;
			_gameController.Clock.SetButtonsInteractable(false);
			_gameController.Clock.FinishedLevel();
			WhatsTheTimeResult result = new WhatsTheTimeResult(_timeElapsed, _incorrectAnswersGiven);
			Finish?.Invoke(result);
		}

		/// <summary>
		/// Increases the wrong answer counter.
		/// </summary>
		private void OnWrongAnswer() => _incorrectAnswersGiven++;
	}
}
