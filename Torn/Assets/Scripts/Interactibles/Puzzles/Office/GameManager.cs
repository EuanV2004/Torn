using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Torn.Office
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        GameObject selectedPiece;

        [SerializeField]
        GameObject emptySpacePrefab;

        [SerializeField]
        List<ScriptableOfficePuzzle> officePuzzlePrefabs;

        ScriptableOfficePuzzle currentLvlPrefabs;

        GameObject emptySpace;

        const int gridSize = 9;

        int currentLvl = 1;

        // Start is called before the first frame update
        void Start()
        {
            GenerateGrid(currentLvl);     // Generate grid at the start of the game
        }

        // Method to randomly generate grid
        void GenerateGrid(int level)
        {
            int[] gridPos = new int[gridSize] {1,2,3,4,5,6,7,8,9};  // List of grid positions

            gridPos = gridPos.OrderBy(x => new System.Random().Next()).ToArray();   // Randomizes the order

            // Set the current level prefabs to the correct prefab list
            currentLvlPrefabs = officePuzzlePrefabs[level - 1];

            // Randomize order of pieces
            currentLvlPrefabs._OfficePuzzlePieces = currentLvlPrefabs._OfficePuzzlePieces.OrderBy(x => new System.Random().Next()).ToArray();

            // Loop through the list of grid positions
            for (int i = 0; i < gridPos.Length; i++)
            {
                // Creates a variable to hold the cooridates of the sqaures
                Vector2 position = new Vector2();

                // Quickly select the right position depending on the grid position from top left - bottom right
                switch (gridPos[i])
                {
                    case 1:
                        {
                            position = new Vector2(-3, 3);

                            break;
                        }
                        case 2:
                        {
                            position = new Vector2(0, 3);

                            break;
                        }
                        case 3:
                        {
                            position = new Vector2(3, 3);
                            break;
                        }
                        case 4:
                        {
                            position = new Vector2(-3, 0);
                            break;
                        }
                        case 5:
                        {
                            position = new Vector2(0, 0);

                            break;
                        }
                        case 6:
                        {
                            position = new Vector2(3, 0);
                            break;
                        }
                        case 7:
                        {
                            position = new Vector2(-3, -3);
                            break;
                        }
                        case 8:
                        {
                            position = new Vector2(0, -3);
                            break;
                        }
                        case 9:
                        {
                            position = new Vector2(3, -3);
                            break;
                        }
                }

                // Make the first square always be the empty square
                if (i == 0)
                {
                    emptySpace = Instantiate(emptySpacePrefab, position, Quaternion.identity);

                    emptySpace.GetComponent<EmptySpaceController>().gm = gameObject.GetComponent<GameManager>();
                }
                else
                {
                    GameObject newPiece = Instantiate(currentLvlPrefabs._OfficePuzzlePieces[i-1], position, Quaternion.identity);

                    newPiece.GetComponent<SlidePiece>().gm = gameObject.GetComponent<GameManager>();
                    newPiece.GetComponent<SlidePiece>().emptySpace = emptySpace.GetComponent<Transform>();
                }
            }
        }

        // Set the piece as selected
        public void SetSelectedPiece(GameObject piece = null)
        {
            selectedPiece = piece;
        }

        // Get the selected piece
        public GameObject GetSelectedPiece()
        {
            return selectedPiece;
        }
    }
}
