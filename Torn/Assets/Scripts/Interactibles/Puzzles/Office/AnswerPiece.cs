using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Torn.Office
{
    public class AnswerPiece : MonoBehaviour
    {
        public GameManager gm;

        [SerializeField]
        bool isCorrect;

        public bool CheckCorrectAnswer()
        {
            return isCorrect;
        }

        void OnMouseDown()
        {
            gm.SetSelectedPiece(gameObject);
        }
    }
}
