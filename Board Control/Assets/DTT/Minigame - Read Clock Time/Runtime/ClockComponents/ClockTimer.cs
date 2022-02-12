using System;
using UnityEngine;
using UnityEngine.UI;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
    /// <summary>
    /// Simple timer class, that keeps track of the passed time.
    /// </summary>
    public class ClockTimer : MonoBehaviour
    {
        /// <summary>
        /// The timer text/number.
        /// </summary>
        private Text _timerText;

        /// <summary>
        /// The time passed in milliseconds.
        /// </summary>
        private float _timer = 0;

        /// <summary>
        /// The time passed in milliseconds.        
        /// /// </summary>
        public float Timer => _timer;

        /// <summary>
        /// Whether the timer is currently on pause.
        /// </summary>
        private bool _paused = true;

        /// <summary>
        /// Gets the necessary components.
        /// </summary>
        void Start() => _timerText = GetComponent<Text>();

        /// <summary>
        /// Updated the time each frame.
        /// </summary>
        private void Update()
        {
            if (!_paused)
            {
                this._timer += Time.deltaTime * 1000f;
                DateTime time = new DateTime().AddSeconds(GetSeconds());
                if (GetSeconds() < 3600f)
                    SetTimerText(time.ToString("mm:ss"));
                else
                    SetTimerText(time.ToString("hh:mm:ss"));
            }
        }

        /// <summary>
        /// Returns the current passed time in milliseconds.
        /// </summary>
        /// <returns>The passed time in milliseconds.</returns>
        public int GetMilliseconds() => Mathf.CeilToInt(_timer);

        /// <summary>
        /// Returns the current passed time in seconds.
        /// </summary>
        /// <returns>The passed time in seconds.</returns>
        public int GetSeconds() => Mathf.CeilToInt(_timer / 1000f);

        /// <summary>
        /// Pauses/Unpauses the timer.
        /// </summary>
        /// <param name="pause">Whether to pause the timer or not.</param>
        public void PauseTimer(bool pause) => _paused = pause;

        /// <summary>
        /// Resets the timer.
        /// </summary>
        public void ResetTimer()
        {
            _timer = 0;
            DateTime time = new DateTime().AddSeconds(GetSeconds());
            if (GetSeconds() < 3600f)
                SetTimerText(time.ToString("mm:ss"));
            else
                SetTimerText(time.ToString("hh:mm:ss"));
        }

        /// <summary>
        /// Sets the text for the timer.
        /// </summary>
        /// <param name="text">The new text.</param>
        public void SetTimerText(string text) => _timerText.text = text;
    }
}
