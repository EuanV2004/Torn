using UnityEngine;

namespace Torn.Office
{
    public class SlidePiece : OfficePiece
    {
        [SerializeField]
        bool isNextToEmpty;

        public Transform emptySpace;

        float squareScale = 3f;

        [SerializeField]
        Vector2 correctPosition;

        [SerializeField]
        bool isInPosition = false;


        void Start()
        {
            switch (name)
            {
                case "Piece 1":
                    {
                        correctPosition = new Vector2(-3, 3);
                        break;
                    }
                case "Piece 2":
                    {
                        correctPosition = new Vector2(0, 3);
                        break;
                    }
                case "Piece 3":
                    {
                        correctPosition = new Vector2(3, 3);
                        break;
                    }
                case "Piece 4":
                    {
                        correctPosition = new Vector2(-3, 0);
                        break;
                    }
                case "Piece 5":
                    {
                        correctPosition = new Vector2(0, 0);
                        break;
                    }
                case "Piece 6":
                    {
                        correctPosition = new Vector2(3, 0);
                        break;
                    }
                case "Piece 7":
                    {
                        correctPosition = new Vector2(-3, -3);
                        break;
                    }
                case "Piece 8":
                    {
                        correctPosition = new Vector2(0, -3);
                        break;
                    }
            }

        }

        // Update is called once per frame
        void Update()
        {
            // Constantly check if the piece is next to the empty space
            IsAdjacentToEmpty();

            CheckPosition();

            base.ChangeSelectedState();
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

        // Method to check if the piece is in the correct position
        void CheckPosition()
        {
            if ((Vector2)transform.position == correctPosition)
            {
                isInPosition = true;
            }
            else
            {
                isInPosition = false;
            }
        }

        // Get if the correct piece is in the correct position
        public bool CheckCorrectPlacement()
        {
            return isInPosition;
        }
    }
}
