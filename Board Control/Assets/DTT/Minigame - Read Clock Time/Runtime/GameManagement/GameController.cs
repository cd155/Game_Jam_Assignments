using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
	///<summary>
	/// Class that handles the generation and interaction of the whats the time game.
	///</summary>
	[RequireComponent(typeof(GameController)), RequireComponent(typeof(TimeSpanGeneration))]
	public class GameController : MonoBehaviour
	{
		/// <summary>
		/// Reference to the clock controller.
		/// </summary>
		[SerializeField]
		[Tooltip("Reference to the clockUI")]
		private ClockController _clock;

		/// <summary>
		/// Settings for the each level of the game.
		/// </summary>
		[SerializeField]
		[Tooltip("Settings for the each level of the game")]
		private LevelSettings[] _levelSettings;

		/// <summary>
		/// Total amount of levels.
		/// </summary>
		private int _totalLevels;

		/// <summary>
		/// Generator for the time spans of the minigame.
		/// </summary>
		private TimeSpanGeneration _timeSpanGenerator;

		/// <summary>
		/// The right choice button.
		/// </summary>
		private ClockButton _correctButton;

		/// <summary>
		/// The last wrong button clicked.
		/// </summary>
		private ClockButton _lastWrongButton;

		/// <summary>
		/// The current correct answer to the round.
		/// </summary>
		private TimeSpan _correctAnswer;

		/// <summary>
		/// Total amount of levels.
		/// </summary>
		public int TotalLevels => _totalLevels;

		/// <summary>
		/// Reference to the clock controller.
		/// </summary>
		public ClockController Clock => _clock;

		/// <summary>
		/// Action for when the game has ended.
		/// </summary>
		public event Action<float> GameEnded;

		/// <summary>
		/// Action for when a wrong button has been pressed.
		/// </summary>
		public event Action WrongButtonPressed;

		/// <summary>
		/// Action for when a correct answer button has been pressed.
		/// </summary>
		public event Action AnswerButtonPressed;

		/// <summary>
		/// Subscribes to events from the ClockUI and starts the game if _playOnStart is selected.
		/// </summary>
		private void Start()
		{
			_timeSpanGenerator = GetComponent<TimeSpanGeneration>();
			_totalLevels = _levelSettings.Length;
		}

		/// <summary>
		/// Generates the game.
		/// </summary>
		///<param name="currentLevel">The current level to generate.</param>
		public void GenerateGame(int currentLevel)
		{
			_clock.UpdateClockButtonAmount(_levelSettings[currentLevel].ButtonAmount);
			_clock.StartLevel();

			_timeSpanGenerator = GetComponent<TimeSpanGeneration>();
			TimeSpan answer = _timeSpanGenerator.GenerateTimeSpan(_levelSettings[currentLevel]);
			List<TimeSpan> deviatedTimes = _timeSpanGenerator.GenerateDeviatedTimeSpan(_levelSettings[currentLevel], answer, _clock.ActiveButtons - 1);

			foreach (ClockButton button in _clock.ChoiceButtons)
			{
				button.ButtonPressed += OnClockButtonPressed;
			}

			_lastWrongButton = null;
			_correctAnswer = answer;

			_clock.DisplayTimeOnHands(answer.Hours, answer.Minutes);
			AssignTimeToButtons(answer, deviatedTimes, _levelSettings[currentLevel].AmPm);
		}

		/// <summary>
		/// Assigns the time span options to the different buttons.
		/// </summary>
		/// <param name="answer">The right answer for the button.</param>
		/// <param name="deviatedTimes">The deviated answers for the button.</param>
		/// <paramref name="amPm"/>Whether or not the time mode is amPm, if false then the time mode is set to 24 hours.</param>
		private void AssignTimeToButtons(TimeSpan answer, List<TimeSpan> deviatedTimes, bool amPm) 
		{
			Random rand = new Random();

			// Choose if it's am or pm.
			bool am = false;
			if (amPm)
			{
				if (rand.Next(0, 2) == 0)
					am = true;

				_clock.SetAmPm(am);
			}
			else
			{
				_clock.SetTwentyFourHours(answer);
			}

			int correctButtonIndex = rand.Next(0, _clock.ActiveButtons);

			_correctButton = _clock.ChoiceButtons[correctButtonIndex];
			_correctButton.SetButtonTime(answer);

			int j = 0;
			for (int i = 0; i < _clock.ActiveButtons; i++) {

				if (i == correctButtonIndex) 
					continue;

				_clock.ChoiceButtons[i].SetButtonTime(deviatedTimes[j]);

				j++;
			}
		}

		/// <summary>
		/// Whenever a clock button is pressed this function gets called.
		/// </summary>
		/// <param name="button">The button that was pressed.</param>
		private void OnClockButtonPressed(ClockButton button)
		{
			if (button.TimeValue == _correctAnswer)
			{
				button.CorrectAnswer(() => {
						GameEnded?.Invoke(_clock.ClockTimer.Timer);
				});

				if (!button.HasBeenPressed)
				{
					AnswerButtonPressed.Invoke();
				}

				foreach (ClockButton clockButton in _clock.ChoiceButtons)
				{
					clockButton.SetInteractable(false);
					button.HasBeenPressed = true;
				}
			}
			else
			{
				if (_lastWrongButton != button)
				{
					WrongButtonPressed.Invoke();
					_lastWrongButton = button;

					TimeSpan correct = _correctAnswer;
					button.IncorrectAnswer(() => {
						if (correct == _correctAnswer)
						{
							button.SetInteractable(false);
							button.HasBeenPressed = true;
						}
					});
				}

			}
		}
	}
}
