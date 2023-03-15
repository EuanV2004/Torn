using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Torn.Office
{
    public class EmptySpaceController : MonoBehaviour
    {
        public GameManager gm;

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
            }
        }
    }
}
