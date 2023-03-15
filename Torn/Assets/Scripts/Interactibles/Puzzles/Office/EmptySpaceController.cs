using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Torn.Office
{
    public class EmptySpaceController : MonoBehaviour
    {
        public GameManager gm;

        [SerializeField]
        bool inCorrectPosition;

        [SerializeField]
        List<Vector2> correctPos = new List<Vector2>();

        // On mouse click
        void OnMouseDown()
        {
            // Check if the selected piece is null and the piece is next to the empty space
            if (gm.GetSelectedPiece() != null && gm.GetSelectedPiece().GetComponent<SlidePiece>().CheckIsAdjacent())
            {
                // Swap postion with the piece
                Vector2 oldPiecePos = gm.GetSelectedPiece().GetComponent<Transform>().position;
                gm.GetSelectedPiece().GetComponent<Transform>().position = gameObject.transform.position;
                gameObject.transform.position = oldPiecePos;

                // Clear Selected Piece once it swaps
                gm.SetSelectedPiece();
            }
        }

        public void CheckCorrectPos(Vector2 pos)
        {
            foreach (Vector2 position in correctPos)
            {
                if (pos == position)
                {
                    inCorrectPosition = true;
                    
                    break;
                }
            }
        }

        public void SetCorrectPositions(List<Vector2> posList)
        {
            foreach (Vector2 pos in posList)
            {
                correctPos.Add(pos);
            }
        }
    }
}
