using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Office
{
    public class EmptySpaceController : MonoBehaviour
    {
        public GameManager gm;

        [SerializeField]
        bool inCorrectPosition;

        [SerializeField]
        List<Vector2> correctPos = new List<Vector2>();
        
        void Update()
        {
            CheckCorrectPos(transform.position);
        }

        // On mouse click
        void OnMouseDown()
        {
            // Check if the selected piece is null
            if (gm.GetSelectedPiece() != null)
            {
                // Check if the tag is a puzzle piece and if the piece is next to the empty space
                if (gm.GetSelectedPiece().tag == "PuzzlePiece" && gm.GetSelectedPiece().GetComponent<SlidePiece>().CheckIsAdjacent())
                {
                    // Swap postion with the piece
                    Vector2 oldPiecePos = gm.GetSelectedPiece().GetComponent<Transform>().position;
                    gm.GetSelectedPiece().GetComponent<Transform>().position = transform.position;
                    gameObject.transform.position = oldPiecePos;

                    // Clear Selected Piece once it swaps
                    gm.SetSelectedPiece();
                }
                // Check if the tag is an answer piece
                else if (gm.GetSelectedPiece().tag == "AnswerPiece")
                {
                    // Check if the empty space is in the correct position and if answer is correct
                    if (inCorrectPosition && gm.GetSelectedPiece().GetComponent<AnswerPiece>().CheckCorrectAnswer() && CheckPuzzlePiecePosition())
                    {
                        // Place the answer on the empty space
                        gm.GetSelectedPiece().GetComponent<Transform>().position = transform.position;

                        // Clear Selected Piece once it swaps
                        gm.SetSelectedPiece();

                        gm.NextLevel();
                    }
                }
            }
        }

        bool CheckPuzzlePiecePosition()
        {
            List<GameObject> pieces = gm.GetPuzzlePieces();

            foreach (GameObject piece in pieces)
            {
                if (!piece.GetComponent<SlidePiece>().CheckCorrectPlacement())
                {
                    return false;
                }
            }

            return true;
        }

        // Checks if the Empty space is in the correct position
        void CheckCorrectPos(Vector2 pos)
        {
            foreach (Vector2 position in correctPos)
            {
                if (pos == position)
                {
                    inCorrectPosition = true;
                    
                    break;
                }

                inCorrectPosition = false;

            }
        }

        // Set the Vector2 position so the empty space knows where is should be
        public void SetCorrectPositions(List<Vector2> posList)
        {
            foreach (Vector2 pos in posList)
            {
                correctPos.Add(pos);
            }
        }
    }
}
