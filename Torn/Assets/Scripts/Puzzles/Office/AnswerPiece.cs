using UnityEngine;

namespace Torn.Office
{
    public class AnswerPiece : OfficePiece
    {
        [SerializeField]
        bool isCorrect;

        public bool CheckCorrectAnswer()
        {
            return isCorrect;
        }
    }
}
