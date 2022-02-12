using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
	///<summary>
	/// Class that handles the face of the clock.
	///</summary>
	public class ClockFace : MonoBehaviour
	{
		/// <summary>
		/// The radius for the clock's face.
		/// </summary>
		[SerializeField]
		[Tooltip("The radius for the clock's face")]
		private float _numberRadius = 240;

		/// <summary>
		/// The list of the text for the numbers.
		/// </summary>
		[SerializeField]
		[Tooltip("The list of the text for the numbers")]
		private List<Text> _numbers;

		/// <summary>
		/// The total hour numbers on the clock's face.
		/// </summary>
		private float _totalHourNumbers;

		/// <summary>
		/// On starts sets the position for the numbers.
		/// </summary>
		private void Start() 
		{
			_totalHourNumbers = _numbers.Count;
			for (int i = 1; i <= _totalHourNumbers; i++)
			{
				_numbers[i - 1].transform.localPosition = NumberToPoint(TimeSpanToRadians(new TimeSpan(i, 0, 0), 90), _numberRadius);
			}
		}

		/// <summary>
		/// Returns a Vector3 position based on TimeSpan input.
		/// </summary>
		/// <param name="radians">Radians from the timespan.</param>
		/// <param name="radius">The radius of the numbers.</param>
		/// <returns>Vector3 position of the time.</returns>
		public Vector3 NumberToPoint(float radians, float radius) 
		{
			Vector3 point = Vector3.zero;

			point.x = radius * Mathf.Cos(radians);
			point.y = radius * Mathf.Sin(radians);

			return point;
		}

		/// <summary>
		/// Takes a timespan and converts it to radians.
		/// </summary>
		/// <param name="time">The time span to convert.</param>
		/// <returns>Vector3 position of the time.</returns>
		private float TimeSpanToRadians(TimeSpan time, float offset) => -(time.Hours / _totalHourNumbers* 360 -offset) * Mathf.Deg2Rad;
	}
}
