using UnityEngine;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
    /// <summary>
    /// The different time intervals.
    /// </summary>
    public enum TimeInterval
    {
        /// <summary>
        /// Allows time spans to be represented in whole hours values.
        /// </summary>
        [InspectorName("Whole Hour")]
        WHOLE_HOUR = 60,

        /// <summary>
        /// Allows time spans to be represented in half hour intervals values.
        /// </summary>
        [InspectorName("Half Hour")]
        HALF_HOUR = 30,

        /// <summary>
        /// Allows time spans to be represented in quarter hour intervals values.
        /// </summary>
        [InspectorName("Quarter Hour")]
        QUARTER_HOUR = 15,

        /// <summary>
        /// Allows time spans to be represented in five minutes intervals values.
        /// </summary>
        [InspectorName("Five Minutes")]
        FIVE_MINUTES = 5
    }

    /// <summary>
    /// Holds the settings for the level of the game.
    /// </summary>
    [CreateAssetMenu(fileName = "Level_Settings_template", menuName = "LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        /// <summary>
        /// The time interval for the level.
        /// </summary>
        [SerializeField]
        [Tooltip("The level time interval type")]
        private TimeInterval _interval;

        /// <summary>
        /// The time interval for the level.
        /// </summary>
        public TimeInterval Interval => _interval;

        /// <summary>
        /// The level time mode, if true the time mode is set to 12hrs and if false 24hrs.
        /// </summary>
        [SerializeField]
        [Tooltip("The level time mode, if true the time mode is set to 12hrs and if false 24hrs")]
        private bool _amPm;

        /// <summary>
        /// The level time mode.
        /// </summary>
        public bool AmPm => _amPm;

        /// <summary>
        /// The hour range between the possible options. 
        /// </summary>
        [SerializeField]
        [Tooltip("The hour range between the possible options")]
        [Range(1, 12)]
        private int _hourOffset = 1;

        /// <summary>
        /// The hour range between the possible options. 
        /// </summary>
        public int HourOffset => _hourOffset;

        /// <summary>
        /// Amount of buttons.
        /// </summary>
        [SerializeField]
        [Tooltip("Amount of buttons")]
        [Range(2, 3)]
        private int _buttonAmount = 3;

        /// <summary>
        /// Amount of buttons.
        /// </summary>
        public int ButtonAmount => _buttonAmount;
    }
}