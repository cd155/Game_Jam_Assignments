using UnityEngine;
using UnityEngine.UI;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
	///<summary>
	/// Class that manages a clock hand.
	///</summary>
	public class ClockHand : MonoBehaviour
	{
		/// <summary>
		/// The hand's rotation between 0 and 1
		/// </summary>
		public float NormalizedValue { get => (_targetRotZ <= 0) ? (_targetRotZ) / -360 : (_targetRotZ - 360) / -360; }

		/// <summary>
		/// The target rotation of the clock hand.
		/// </summary>
		private float _targetRotZ;

		/// <summary>
		/// Sets the hand's rotation with hours and minutes to give a more accurate hour rotation, used by the hour hand.
		/// </summary>
		/// <param name="hours">The hour you want it to point to.</param>
		public void SetHourRotation(int hours, int minutes, float stepSpeed) 
		{
			hours %= 12;
			minutes %= 60;
			_targetRotZ = (hours / (float)12 * 360) + (minutes / (float)60 * 30);
			Rotate(_targetRotZ, stepSpeed);
		}

		/// <summary>
		/// Sets the hand's rotation with minutes, used for the minute hand.
		/// </summary>
		/// <param name="minutes">The minute you want it to point to.</param>
		/// <param name="stepSpeed">The speed of the rotation.</param>
		public void SetMinuteRotation(int minutes, float stepSpeed) 
		{
			// If minutes are 0 then set to 60 to be able to rotate towards the new time.
			if (minutes == 0) 
				minutes = 60;

			_targetRotZ = minutes / (float)60 * 360;

			Rotate(_targetRotZ, stepSpeed);
		}

		/// <summary>
		/// Rotates the clock hand.
		/// </summary>
		/// <param name="target">The target rotation degree.</param>
		/// <param name="stepSpeed">The speed of the rotation.</param>
		private void Rotate(float target, float stepSpeed) 
		{

			if (target == 0) 
				target = 360;

			float time = target * stepSpeed;
			StartCoroutine(Animations.Value(transform.localEulerAngles.z, -target, time, (value) => transform.localEulerAngles = new Vector3(0, 0, value)));
		}
	}
}
