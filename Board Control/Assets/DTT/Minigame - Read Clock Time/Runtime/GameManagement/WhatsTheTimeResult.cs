using System.Text;

namespace DTT.MiniGame.WhatsTheTime.Runtime
{
    /// <summary>
    /// Class holding the result info of a jigsaw game.
    /// </summary>
    public class WhatsTheTimeResult
    {
        /// <summary>
        /// Time it took to finish the game.
        /// </summary>
        public readonly float timeTaken;

        /// <summary>
        /// Amount of times a wrong answer was given
        /// </summary>
        public readonly int wrongButtonCount;

        /// <summary>
        /// Sets the result info.
        /// </summary>
        /// <param name="timeTaken">Time the game took</param>
        /// <param name="incorrectAnswers">Amount of times a wrong answer was given</param>
        public WhatsTheTimeResult(float timeTaken, int incorrectAnswers)
        {
            this.timeTaken = timeTaken;
            this.wrongButtonCount = incorrectAnswers;
        }

        /// <summary>
        /// Returns result info in string format for debugging.
        /// </summary>
        /// <returns>Result in string format</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Time taken (s): ");
            sb.Append(timeTaken);
            sb.Append('\t');
            sb.Append("Amount of wrong answers: ");
            sb.Append(wrongButtonCount);

            return sb.ToString();
        }
    }
}