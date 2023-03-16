using UnityEngine;

namespace Torn.Office
{
    public class SlidePiece : MonoBehaviour
    {
        [SerializeField]
        bool isNextToEmpty;

        public GameManager gm;

        public Transform emptySpace;

        float squareScale = 3f;

        // Update is called once per frame
        void Update()
        {
            // Constantly check if the piece is next to the empty space
            IsAdjacentToEmpty();
        }


        // Method used to check for the empty space
        void IsAdjacentToEmpty()
        {
            // Calculate the x distance and y distance
            float dx = Mathf.Abs(emptySpace.position.x - transform.position.x);
            float dy = Mathf.Abs(emptySpace.position.y - transform.position.y);

            // Check if the piece is adjacent to the empty space
            if ((dx == squareScale && dy == 0) || (dy == squareScale && dx == 0))
            {
                isNextToEmpty = true;
            }
            else
            {
                isNextToEmpty = false;
            }
        }

        // Get is the piece is next to the empty space
        public bool CheckIsAdjacent()
        {
            return isNextToEmpty;
        }

        // Make the piece clicked on as the selected piece
        void OnMouseDown()
        {
            gm.SetSelectedPiece(gameObject);
        }
    }
}
