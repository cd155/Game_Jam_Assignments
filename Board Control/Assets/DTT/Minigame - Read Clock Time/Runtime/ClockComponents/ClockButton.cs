using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
    /// <summary>
    /// Handles the buttons for the time options.
    /// </summary>
    public class ClockButton : MonoBehaviour
    {
        /// <summary>
        /// The reference to the the AM / PM text.
        /// </summary>
        [SerializeField]
        [Tooltip("The reference to the the AM / PM text")]
        private Text _amPmText;

        /// <summary>
        /// The reference to the time text.
        /// </summary>
        [SerializeField]
        [Tooltip("The reference to the time text")]
        private Text _timeText;

        /// <summary>
        /// The time that the fading animation should take.
        /// </summary>
        [SerializeField]
        [Tooltip("The time that the fading animation should take.")]
        [Range(0.1f, 1.5f)]
        private float _fadeAnimTime = 0.2f;

        /// <summary>
        /// The time that the scaling animation should take.
        /// </summary>
        [SerializeField]
        [Tooltip("The time that the scaling animation should take.")]
        [Range(0.1f, 0.8f)]
        private float _scaleAnimTime = 0.4f;

        /// <summary>
        /// The maximum size for the scaling animation.
        /// </summary>
        [SerializeField]
        [Tooltip("The maximum size for the scaling animation.")]
        [Range(1.1f, 1.5f)]
        private float _maxScalingSize = 1.2f;

        /// <summary>
        /// The minimum size for the scaling animation.
        /// </summary>
        [SerializeField]
        [Tooltip("The minimum size for the scaling animation.")]
        [Range(0.6f, 0.9f)]
        private float _minScalingSize = 0.8f;

        /// <summary>
        /// The strength for the shake animation of the button.
        /// </summary>
        [SerializeField]
        [Tooltip("The strength for the shake animation of the button.")]
        [Range(1f, 10f)]
        private int _shakeStrength = 5;

        /// <summary>
        /// Amount of times that the button should shake in the animation.
        /// </summary>
        [SerializeField]
        [Tooltip("Amount of times that the button should shake in the animation.")]
        [Range(2f, 10f)]
        private int _shakeAmount = 5;

        /// <summary>
        /// Amount of times that the button should flash.
        /// </summary>
        [SerializeField]
        [Tooltip("Amount of times that the button should flash.")]
        [Range(2f, 8f)]
        private int _colorFlashes = 3;

        /// <summary>
        /// Image component of the button.
        /// </summary>
        private Image _buttonImage;

        /// <summary>
        /// The current time span to show for the button.
        /// </summary>
        private TimeSpan _timeValue;

        /// <summary>
        /// The current time span to show for the button.
        /// </summary>
        public TimeSpan TimeValue => _timeValue;

        /// <summary>
        /// Gets called when the button is pressed.
        /// </summary>
        public event Action<ClockButton> ButtonPressed;

        /// <summary>
        /// Reference to the button component.
        /// </summary>
        private Button _uiButton;

        /// <summary>
        /// Whether or not the button has been pressed during the level.
        /// </summary>
        private bool _hasBeenPressed;

        /// <summary>
        /// Whether  or not the button has been pressed during the level.
        /// </summary>
        public bool HasBeenPressed
        {
            get => _hasBeenPressed;
            set => _hasBeenPressed = value;
        }

        /// <summary>
        /// Variable for when the animations is playing.
        /// </summary>
        private bool _animationIsPlaying = false;

        /// <summary>
        /// Get and Set for the _animationIsPlaying.
        /// </summary>
        public bool AnimationIsPlaying
        {
            get => _animationIsPlaying;
            set => _animationIsPlaying = value;
        }

        /// <summary>
        /// The current time mode.
        /// </summary>
        private bool _amPm;

        /// <summary>
        /// The target text for the clock button time.
        /// </summary>
        private string _targetText;

        /// <summary>
        /// Gets references to required components on awake.
        /// </summary>
        private void Awake()
        {
            _uiButton = GetComponent<Button>();
            _buttonImage = GetComponent<Image>();
        }

        /// <summary>
        /// On enable adds listener to button.
        /// </summary>
        private void OnEnable()
        {
            _uiButton.onClick.AddListener(OnButtonPressed);
        }

        /// <summary>
        /// On disable removes listener from button.
        /// </summary>
        private void OnDisable()
        {
            _uiButton.onClick.RemoveListener(OnButtonPressed);
        }

        /// <summary>
        /// Sets the time to the button.
        /// </summary>
        /// <param name="time">The buttons new time value.</param>
        public void SetButtonTime(TimeSpan time)
        {
            _targetText = $"{ time:hh\\:mm}";
            StartCoroutine(FadeTimeText());
            _timeValue = time;
        }

        /// <summary>
        /// Animation that fades the time text.
        /// </summary>
        private IEnumerator FadeTimeText()
        {
            StartCoroutine(Animations.Value(1, 0, _fadeAnimTime, (value) => _timeText.color = new Color(_timeText.color.r, _timeText.color.g, _timeText.color.b, value)));
            StartCoroutine(Animations.Value(1, 0, _fadeAnimTime, (value) => _amPmText.color = new Color(_amPmText.color.r, _amPmText.color.g, _amPmText.color.b, value)));
            yield return new WaitForSeconds(_fadeAnimTime);
            _timeText.text = _targetText;
            yield return new WaitForSeconds(_fadeAnimTime);
            StartCoroutine(Animations.Value(_timeText.color.a, 1, _fadeAnimTime, (value) => _timeText.color = new Color(_timeText.color.r, _timeText.color.g, _timeText.color.b, value)));
            StartCoroutine(Animations.Value(_amPmText.color.a, 1, _fadeAnimTime, (value) => _amPmText.color = new Color(_amPmText.color.r, _amPmText.color.g, _amPmText.color.b, value)));
            yield return new WaitForSeconds(_fadeAnimTime);
        }

        /// <summary>
        /// Gets called when the button is pressed.
        /// </summary>
        public void OnButtonPressed() => ButtonPressed?.Invoke(this);

        /// <summary>
        /// Starts the coroutine for playing the error animation.
        /// </summary>
        /// <param name="callback">On complete.</param>
        public void IncorrectAnswer(Action callback)
        {
            if (_animationIsPlaying) return;
                StartCoroutine(PlayIncorrectAnimation(callback));
        }

        /// <summary>
        /// Starts the coroutine for playing the good animation.
        /// </summary>
        /// <param name="callback">On complete.</param>
        public void CorrectAnswer(Action callback)
        {
            if (_animationIsPlaying) 
                return;

            StartCoroutine(PlayCorrectAnimation(callback));
        }

        /// <summary>
        /// Sets the button interactability and plays the animation.
        /// </summary>
        /// <param name="interactable">Whether or not the button should be interactable.</param>
        public void SetInteractable(bool interactable)
        {
            if (_hasBeenPressed)
                return;

            _uiButton.interactable = interactable;

            if (!_animationIsPlaying)
            {
                if (!interactable)
                {
                    StartCoroutine(Animations.Value(_buttonImage.color.r, 0.4f, _fadeAnimTime, (value) => _buttonImage.color = new Color(value, value, value)));
                    ScaleAnimation(_minScalingSize, _scaleAnimTime);
                }
                else
                {
                    StartCoroutine(Animations.Value(_buttonImage.color.r, 1, _fadeAnimTime, (value) => _buttonImage.color = new Color(value, value, value)));
                    ScaleAnimation(1, _scaleAnimTime);
                }
            }
        }

        /// <summary>
        /// Sets the mode of the clock (24 Hours or AM/PM).
        /// </summary>
        /// <param name="amPm">The time mode for the button.</param>
        public void SetTimeMode(bool amPm) => _amPmText.gameObject.SetActive(amPm);

        /// <summary>
        /// Sets the text to AM or PM.
        /// </summary>
        /// <param name="am">If the text should be set to am.</param>
        public void SetAmPm(bool am) => _amPmText.text = (am)? "AM" : "PM";

        /// <summary>
        /// Animation that shakes the button.
        /// </summary>
        /// <param name="count">Times that the shaking effect is played.</param>
        /// <param name="callback">On complete.</param>
        private IEnumerator Shake(int count, Action callback)
        {
            for (int i=0; i<count; ++i)
            {
                StartCoroutine(Animations.Value(transform.localEulerAngles.z, _shakeStrength, 0.2f, (value) => transform.localEulerAngles = new Vector3(0, 0, value)));
                yield return new WaitForSeconds(0.1f);
            }
            StartCoroutine(Animations.Value(transform.localEulerAngles.z, 0, 0.2f, (value) => transform.localEulerAngles = new Vector3(0, 0, value)));
            callback();
            yield return null;
        }

        /// <summary>
        /// Animation for the color fading. If the chosen button is correct it will flash with a green color. If it is not correct then it will flash with a red color.
        /// </summary>
        /// <param name="img">The image to apply the color fading to.</param>
        /// <param name="correct">Whether it should flash with the correct or incorrect color.</param>
        /// <param name="time">The time that the fading animations should take.</param>
        /// <param name="count">The times that the color should flash.</param>
        /// <returns></returns>
        private IEnumerator ColorFadeImage(Image img, bool correct, float time, int count)
        {
            float startValue = img.color.r;
            float endValue = 0;

            for (int i = 0; i < count; ++i)
            {
                if (correct)
                    StartCoroutine(Animations.Value(startValue, endValue, time/count, (value) => img.color = new Color(value, img.color.g, value)));
                else
                    StartCoroutine(Animations.Value(startValue, endValue, time/count, (value) => img.color = new Color(img.color.r, value, value)));

                yield return new WaitForSeconds(time/count);
                StartCoroutine(Animations.Value(startValue, 0.6f, time/count, (value) => img.color = new Color(value, value, value)));
            }

            if (!correct)
                StartCoroutine(Animations.Value(1, 0.6f, time, (value) => img.color = new Color(value, value, value)));
            else
                StartCoroutine(Animations.Value(1, 0.6f, time, (value) => img.color = new Color(value, value, value)));
        }

        /// <summary>
        /// Plays the animation for when the incorrect option has been selected.
        /// </summary>
        /// <param name="callback">On complete.</param>
        private IEnumerator PlayIncorrectAnimation(Action callback)
        {
            _animationIsPlaying = true;

            StartCoroutine(ColorFadeImage(_buttonImage, false, _fadeAnimTime, _colorFlashes));
            StartCoroutine(Shake(_shakeAmount, callback));

            yield return new WaitForSeconds(_fadeAnimTime);

            _animationIsPlaying = false;
        }

        /// <summary>
        /// Plays the animation for when the correct option has been selected.
        /// </summary>
        /// <param name="callback">On complete.</param>
        private IEnumerator PlayCorrectAnimation(Action callback)
        {
            if (_hasBeenPressed)
                yield break;

            _animationIsPlaying = true;

            StartCoroutine(ColorFadeImage(_buttonImage, true, _fadeAnimTime * 2, 1));
            ScaleAnimation(_maxScalingSize, _scaleAnimTime);
            yield return new WaitForSeconds(_scaleAnimTime);
            // Scales back to original size.
            ScaleAnimation(1f, _scaleAnimTime);

            _animationIsPlaying = false;
            callback?.Invoke();
        }

        /// <summary>
        /// Scaling of the button animation.
        /// </summary>
        /// <param name="to">End scale value.</param>
        /// <param name="duration">Duration of the animation.</param>
        private void ScaleAnimation(float to, float duration) => StartCoroutine(Animations.Value(transform.localScale.x, to, duration, (value) => transform.localScale = new Vector3(value,value,value)));
    }
}
