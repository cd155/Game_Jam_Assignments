using UnityEngine;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
	///<summary>
	/// Class that handles the DayNightSkyBox.
	///</summary>
	public class DayNightSkyBox : MonoBehaviour
	{
		/// <summary>
		/// Previous z value of rotation.
		/// </summary>
		private float _prevZ;

		/// <summary>
		/// Whether or not it's the time is set to am.
		/// </summary>
		private bool _am = false;

		/// <summary>
		/// Whether or not it's the time is set to am.
		/// </summary>
		public bool Am { set => _am = value; }

		/// <summary>
		/// Updates the rotation of the DayNightSkyBox.
		/// </summary>
		/// <param name="eulerAnglesZ">Rotation z.</param>
		public void UpdateRotation(float eulerAnglesZ) 
		{
			float newZ = Mathf.Clamp(eulerAnglesZ, 0, 360);

			newZ /= 2;

			if (_am) 
				newZ += 180;

			_prevZ = newZ;

			transform.rotation = Quaternion.Euler(0, 0, -(_prevZ+newZ));
		}
	}
}
