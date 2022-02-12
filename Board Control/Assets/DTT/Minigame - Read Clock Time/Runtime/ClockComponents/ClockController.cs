using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
	///<summary>
	/// Handles the different components of the clock and choice buttons.
	///</summary>
	public class ClockController : MonoBehaviour
	{
		/// <summary>
		/// The hour hand of the clock.
		/// </summary>
		[SerializeField]
		[Tooltip("The hour hand of the clock")]
		private ClockHand _hourHand;

		/// <summary>
		/// The minutes hand of the clock.
		/// </summary>
		[SerializeField]
		[Tooltip("The minute hand of the clock")]
		private ClockHand _minuteHand;

		/// <summary>
		/// The layout group for the buttons.
		/// </summary>
		[SerializeField]
		[Tooltip("The layout group for the buttons")]
		private LayoutGroup _buttonsLayout;

		/// <summary>
		/// The choice button.
		/// </summary>
		[SerializeField]
		[Tooltip("The choice button")]
		private ClockButton _choiceButtonPrefab;

		/// <summary>
		/// The timer for the game.
		/// </summary>
		[SerializeField]
		[Tooltip("The timer for the game")]
		private ClockTimer _clockTimer;

		/// <summary>
		/// Reference to the sky box.
		/// </summary>
		[SerializeField]
		[Tooltip("Reference to the sky box")]
		private DayNightSkyBox _dayNightSkyBox;

		/// <summary>
		/// The face of the clock.
		/// </summary>
		[SerializeField]
		[Tooltip("The face of the clock")]
		private ClockFace _clockFace;

		/// <summary>
		/// The buttons for the time choices.
		/// </summary>
		private List<ClockButton> _choiceButtons = new List<ClockButton>();

		/// <summary>
		/// The amount of active buttons.
		/// </summary>
		private int _activeButtons = 0;

		/// <summary>
		/// Whether or not the game can be reset.
		/// </summary>
		private bool _canBeReset = true;

		/// <summary>
		/// Whether or not the game has already finished.
		/// </summary>
		private bool _buttonsAreInteractable = true;

		/// <summary>
		/// The timer for the game.
		/// </summary>
		public ClockTimer ClockTimer => _clockTimer;

		/// <summary>
		/// The face of the clock.
		/// </summary>
		public ClockFace ClockFace => _clockFace;

		/// <summary>
		/// The getter for choice buttons.
		/// </summary>
		public ReadOnlyCollection<ClockButton> ChoiceButtons => _choiceButtons.AsReadOnly();

		/// <summary>
		/// Getter for the amount of active buttons.
		/// </summary>
		public int ActiveButtons => _activeButtons;

		/// <summary>
		/// Whether or not the game can be reset.
		/// </summary>
		public bool CanBeReset => _canBeReset;

		/// <summary>
		/// The current time displayed on the clock.
		/// </summary>
		public TimeSpan CurrentTime
		{
			get => new TimeSpan(Mathf.FloorToInt(_hourHand.NormalizedValue * 12), Mathf.CeilToInt(_minuteHand.NormalizedValue * 60), 0);
			set => DisplayTimeOnHands(value.Hours, value.Minutes);
		}

		/// <summary>
		/// On update, updates the sky box rotation.
		/// </summary>
		private void Update() => _dayNightSkyBox.UpdateRotation(_hourHand.transform.eulerAngles.z);

		/// <summary>
		/// Pauses the game UI.
		/// </summary>
		public void PauseGame() 
		{
			_clockTimer.PauseTimer(true);
			SetButtonsInteractable(false); 
		}

		/// <summary>
		/// Continues the game UI.
		/// </summary>
		public void ContinueGame()
		{
			_clockTimer.PauseTimer(false);
			SetButtonsInteractable(true);
		}

		/// <summary>
		/// Starts the UI for the level.
		/// </summary>
		public void StartLevel() 
		{
			_canBeReset = false;
			StartCoroutine(WaitForReset(1f));

			_buttonsAreInteractable = true;
			ResetButtons();
			SetButtonsInteractable(true);

			_clockTimer.ResetTimer();
			_clockTimer.PauseTimer(false);
		}

		/// <summary>
		/// Finishes the level by pausing the timer and showing the play button.
		/// </summary>
		public void FinishedLevel()
		{
			_buttonsAreInteractable = false;
			_clockTimer.PauseTimer(true);
		}

		/// <summary>
		/// Activates all the UI buttons.
		/// </summary>
		/// <param name="active">Whether or not the buttons should be set active.</param>
		public void SetAllButtonsActive(bool active) 
		{
			for (int i = 0; i < _activeButtons; ++i)
			{
				_choiceButtons[i].gameObject.SetActive(active);
			}
		}

		/// <summary>
		/// Display the time on the UI clockhands.
		/// </summary>
		/// <param name="hours">Amount of hours to set to.</param>
		/// <param name="minutes">Amount of minutes to set to.</param>
		/// <param name="stepSpeed">Animation time for each frame.</param>
		public void DisplayTimeOnHands(int hours, int minutes, float stepSpeed = 0.005f) 
		{
			_hourHand.SetHourRotation(hours, minutes, stepSpeed);
			_minuteHand.SetMinuteRotation(minutes, stepSpeed);
		}

		/// <summary>
		/// Disables or Enables the interaction with the multiple choice buttons.
		/// </summary>
		/// <param name="interactable">Whether or not the buttons should be interactable.</param>
		public void SetButtonsInteractable(bool interactable) 
		{
			if (interactable && !_buttonsAreInteractable)
				return;

			for (int i = 0; i < _activeButtons; ++i)
				_choiceButtons[i].SetInteractable(interactable);
		}

		/// <summary>
		/// Resets the choice buttons to it's initial state.
		/// </summary>
		public void ResetButtons()
		{
			SetButtonsInteractable(true);
			for (int i = 0; i < _activeButtons; ++i)
				_choiceButtons[i].HasBeenPressed = false;
		}

		/// <summary>
		/// Limits the time in which the reset functionality can be used.
		/// </summary>
		/// <param name="time">the time it should take for resetting to work again.</param>
		/// <returns></returns>
		private IEnumerator WaitForReset(float time)
		{
			yield return new WaitForSeconds(time);
			_canBeReset = true;
		}

		/// <summary>
		/// Sets the amount of buttons for the level.
		/// </summary>
		public void UpdateClockButtonAmount(int amount)
		{
			if (_activeButtons < amount)
				CreateButtons(amount-_activeButtons);

			else if (_activeButtons > amount)
				DeleteButtons(amount);
			
			_activeButtons = amount;
		}

		/// <summary>
		/// Creates new buttons.
		/// </summary>
		/// <param name="amount">The amount of new buttons.</param>
		private void CreateButtons(int amount)
		{
			for (int i = 0; i < amount; ++i)
			{
				ClockButton newButton = Instantiate(_choiceButtonPrefab, transform);
				newButton.transform.SetParent(_buttonsLayout.transform);
				_choiceButtons.Add(newButton);
			}
		}

		/// <summary>
		/// Deletes buttons.
		/// </summary>
		/// <param name="amount">The amount of buttons to delete.</param>
		private void DeleteButtons(int amount)
		{
			for (int j = _activeButtons - 1; j >= amount; --j)
			{
				Destroy(_choiceButtons[j].gameObject);
				_choiceButtons.RemoveAt(j);
			}
		}

		/// <summary>
		/// Sets the UI's time mode to 24 hours.
		/// </summary>
		/// <param name="answer">The correct time span using 24 hours.</param>
		public void SetTwentyFourHours(TimeSpan answer)
		{
			for (int i = 0; i < _activeButtons; ++i)
			{
				_choiceButtons[i].SetTimeMode(false);
			}

			if (answer.Hours >= 12)
				_dayNightSkyBox.Am = false;
			else
				_dayNightSkyBox.Am = true;
		}

		/// <summary>
		/// Sets the UI to either am or pm.
		/// </summary>
		/// <param name="am">If the time should be am.</param>
		public void SetAmPm(bool am)
		{
			_dayNightSkyBox.Am = am;
			for (int i = 0; i < _activeButtons; ++i)
			{
				_choiceButtons[i].SetTimeMode(true);
				_choiceButtons[i].SetAmPm(am);
			}
		}
	}
}
