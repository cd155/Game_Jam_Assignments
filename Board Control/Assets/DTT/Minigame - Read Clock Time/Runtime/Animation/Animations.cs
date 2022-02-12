﻿using System;
using System.Collections;
using UnityEngine;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
    /// <summary>
    /// Class to handle basic animations.
    /// </summary>
    public static class Animations
    {
        /// <summary>
        /// Handles basic lineair transition from one float value to another.
        /// </summary>
        /// <param name="from">Start value.</param>
        /// <param name="to">End value.</param>
        /// <param name="time">Duration.</param>
        /// <param name="onValueChanged">Invoked when the value changes.</param>
        /// <param name="delay">Delay before the value change.</param>
        public static IEnumerator Value(float from, float to, float time, Action<float> onValueChanged, float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            float value = from;
            float startTime = Time.time;
            while (value != to)
            {
                float percValue = (Time.time - startTime) / time;
                value = from + ((to - from) * percValue);

                if ((from > to && value < to) || (from < to && value > to))
                    value = to;
                onValueChanged(value);

                yield return new WaitForEndOfFrame();
            }
            yield break;
        }
    }
}