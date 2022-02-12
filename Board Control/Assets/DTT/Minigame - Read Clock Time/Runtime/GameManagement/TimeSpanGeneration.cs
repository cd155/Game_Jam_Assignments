using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
    /// <summary>
    /// Class that handles the generation of time spans.
    /// </summary>
    public class TimeSpanGeneration : MonoBehaviour
    {
        /// <summary>
        /// Generates the correct time span.
        /// </summary>
        /// <param name="settings">The settings for the level.</param>
        /// <returns>The generated time span.</returns>
        public TimeSpan GenerateTimeSpan(LevelSettings settings)
        {
            bool amPm = settings.AmPm;
            TimeInterval interval = settings.Interval;

            Random rand = new Random();

            int maxHours = amPm ? 12 : 24;

            int correctHours = rand.Next(1, maxHours);

            int correctMinutes = rand.Next(0, (60 / (int)interval)) * (int)interval;

            TimeSpan answer = new TimeSpan(correctHours, correctMinutes, 0);

            return answer;
        }

        /// <summary>
        /// Generates deviated time spans.
        /// </summary>
        /// <param name="settings">The settings for the level.</param>
        /// <param name="originalTime">The original time to deviate from.</param>
        /// <param name="amount">The amount of time spans to generate.</param>
        /// <returns>The list of generated time spans.</returns>
        public List<TimeSpan> GenerateDeviatedTimeSpan(LevelSettings settings, TimeSpan originalTime, int amount)
        {
            int range = settings.HourOffset;
            bool amPm = settings.AmPm;
            TimeInterval interval = settings.Interval;

            Random random = new Random();
            List<TimeSpan> deviatedTimes = new List<TimeSpan>();
            List<TimeSpan> deviations = new List<TimeSpan>();

            // Prevent's the time span generation to give the same value as the original answer in the case of a 12 hour range on amPm.
            if (amPm && range == 12)
                range = 11;

            if (range < amount / 2)
                range = amount;

            int maxDeviation = range;

            for (int i = 0; i < amount; i++)
            {
                TimeSpan temp;
                int count = 0;
                while (true)
                {
                    bool breakOut = true;
                    int deviateAmount = random.Next(1, maxDeviation);
                    int minutes = (int)interval * deviateAmount;
                    int deviateSide = random.Next(0, 2);

                    if (deviateSide == 0)
                        temp = new TimeSpan(0, -minutes, 0);
                    else
                        temp = new TimeSpan(0, minutes, 0);

                    foreach (TimeSpan previousTime in deviations)
                    {
                        if (temp == previousTime)
                            breakOut = false;
                    }

                    if (breakOut)
                        break;

                    count++;
                }
                deviations.Add(temp);
            }
            foreach (TimeSpan deviate in deviations)
            {
                TimeSpan deviatedTime = originalTime + deviate;

                if (amPm && deviatedTime > new TimeSpan(12, 0, 0))
                    deviatedTime -= new TimeSpan(12, 0, 0);

                if (deviatedTime == TimeSpan.Zero)
                    deviatedTime = new TimeSpan(12, 0, 0);

                deviatedTimes.Add(deviatedTime);
            }
            return deviatedTimes;
        }
    }
}
