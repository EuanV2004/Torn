using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Office
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] bool hardMode = false;

        [SerializeField]
        Transform puzzlePieceParent, answerPieceParent;

        [SerializeField]GameObject selectedPiece;

        [SerializeField]GameObject emptySpacePrefab;
        [SerializeField]List<Transform> answerPoses;

        [SerializeField] List<ScriptableOfficePuzzle> officePuzzlePrefabs;
        [SerializeField]List<ScriptableOfficeAnswer> officeAnswerPrefabs;

        [SerializeField] List<GameObject> hintPrefabs, solutionPrefabs;

        [SerializeField] GameObject helpMenu, helpSection;

        ScriptableOfficeAnswer currentAnswerPrefabs;
        ScriptableOfficePuzzle currentLvlPrefabs;

        KeyCode helpButton = KeyCode.E, solutionButton = KeyCode.Q;
        [SerializeField] float solutionUnlockTimer = 15f;
        [SerializeField] bool helpMenuOpen, solutionUnlocked;

        GameObject emptySpace;
        const int gridSize = 9;
        public int currentLvl = 1;

        [SerializeField] Torn.Interact.PlayerInteract player;

        // Start is called before the first frame update
        void Start()
        {
            helpMenu.SetActive(false);
            helpSection.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            player = FindObjectOfType<Torn.Interact.PlayerInteract>();
            if (hardMode)
            {
                GenerateGrid(currentLvl);        // Generate grid at the start of the game
            }
            else
            {
                GeneratePattern(currentLvl);    // Generates pattern at the start of the game
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(helpButton))
            {
                HelpMenu();
                
            }

            if (Time.timeSinceLevelLoad >= solutionUnlockTimer && !solutionUnlocked)
            {
                solutionUnlocked = true;
            }

            if (Input.GetKeyDown(solutionButton) && helpMenuOpen)
            {
                GiveSolution();
            }
        }

        void HelpMenu()
        {
            if (!helpMenuOpen)
            {
                helpMenuOpen = true;

                helpMenu.SetActive(true);
                helpSection.SetActive(true);

                Instantiate(hintPrefabs[currentLvl - 1], helpSection.transform.position, Quaternion.Euler(0, 0, 0), helpSection.transform);
            }
            else
            {
                helpMenuOpen = false;

                helpMenu.SetActive(false);
                helpSection.SetActive(false);

                foreach (Transform child in helpSection.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }

        }

        void GiveSolution()
        {
            if (solutionUnlocked)
            {
                foreach (Transform child in helpSection.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                Instantiate(solutionPrefabs[currentLvl - 1], helpSection.transform.position, Quaternion.Euler(0, 0, 0), helpSection.transform);
            }
        }

        // Method to randomly generate grid
        void GenerateGrid(int level)
        {

            int[] gridPos = new int[gridSize] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };  // List of grid positions

            gridPos = gridPos.OrderBy(x => new System.Random().Next()).ToArray();   // Randomizes the order

            // Set the current level prefabs to the correct prefab list
            currentLvlPrefabs = officePuzzlePrefabs[level - 1];

            // Randomize order of pieces
            currentLvlPrefabs._OfficePuzzlePieces = currentLvlPrefabs._OfficePuzzlePieces.OrderBy(x => new System.Random().Next()).ToArray();

            // Loop through the list of grid positions
            for (int i = 0; i < gridPos.Length; i++)
            {
                // Get the position on the grid
                Vector2 position = GetFixedPosition(gridPos[i]);

                // Make the first square always be the empty square
                if (i == 0)
                {
                    emptySpace = Instantiate(emptySpacePrefab, position, Quaternion.identity);

                    emptySpace.GetComponent<EmptySpaceController>().gm = GetComponent<GameManager>();
                }
                else
                {
                    // Add the puzzle pieces into the board
                    GameObject newPiece = Instantiate(currentLvlPrefabs._OfficePuzzlePieces[i - 1], position, Quaternion.identity, puzzlePieceParent);

                    newPiece.GetComponent<SlidePiece>().gm = GetComponent<GameManager>();
                    newPiece.GetComponent<SlidePiece>().emptySpace = emptySpace.GetComponent<Transform>();
                }
            }

            GetAnswerKeys(level);   // Get the answers for the puzzle
            SetAnswerPositions(level, emptySpace);   // Set the correct position for the empty space to be
        }

        // Method creates a fix pattern on the grid
        void GeneratePattern(int level)
        {
            // Set the current level prefabs to the correct prefab list
            currentLvlPrefabs = officePuzzlePrefabs[level - 1];

            switch (level)
            {
                case 1:
                    {
                        LevelOnePattern();
                        break;
                    }
                case 2:
                    {
                        LevelTwoPattern();
                        break;
                    }
                case 3:
                    {
                        LevelThreePattern();
                        break;
                    }
            }

            GetAnswerKeys(level);   // Get the answers for the puzzle
            SetAnswerPositions(level, emptySpace);   // Set the correct position for the empty space to be
        }

        // Fixed the position of pieces
        Vector2 GetFixedPosition(int gPos)
        {
            /* NUMBER POSITION
             * 1 2 3
             * 4 5 6
             * 7 8 9
             */

            Vector2 position = new Vector2();

            switch (gPos)
            {
                // Top Left
                case 1:
                    {
                        position = new Vector2(-1.375f, 2.875f);

                        break;
                    }
                // Top Center
                case 2:
                    {
                        position = new Vector2(0.125f, 2.875f);

                        break;
                    }
                // Top Right
                case 3:
                    {
                        position = new Vector2(1.625f, 2.875f);
                        break;
                    }
                // Middle Left
                case 4:
                    {
                        position = new Vector2(-1.375f, 1.375f);
                        break;
                    }
                // Dead Center
                case 5:
                    {
                        position = new Vector2(0.125f, 1.375f);

                        break;
                    }
                // Middle Right
                case 6:
                    {
                        position = new Vector2(1.625f, 1.375f);
                        break;
                    }
                // Bottom Left
                case 7:
                    {
                        position = new Vector2(-1.375f, -0.125f);
                        break;
                    }
                // Bottom Middle
                case 8:
                    {
                        position = new Vector2(0.125f, -0.125f);
                        break;
                    }
                // Bottom Right
                case 9:
                    {
                        position = new Vector2(1.625f, -0.125f);
                        break;
                    }
            }

            return position;
        }

        // Level 1 Pattern
        void LevelOnePattern()
        {
            emptySpace = Instantiate(emptySpacePrefab, GetFixedPosition(8), emptySpacePrefab.transform.rotation);
            emptySpace.GetComponent<EmptySpaceController>().gm = GetComponent<GameManager>();

            List<GameObject> levelPieces = currentLvlPrefabs._OfficePuzzlePieces.ToList();

            List<int> gridPos = new List<int>() {1, 2, 3, 4, 7 };

            GameObject newPiece = null;
            for (int i = 1; i <= levelPieces.Count; i++)
            {
                switch (i)
                {
                    case 5:
                        {
                            newPiece = Instantiate(levelPieces[i-1], GetFixedPosition(6), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    case 6:
                        {
                            newPiece = Instantiate(levelPieces[i-1], GetFixedPosition(9), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    case 8:
                        {
                            newPiece = Instantiate(levelPieces[i-1], GetFixedPosition(5), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    default:
                        {


                            newPiece = Instantiate(levelPieces[i-1], GetFixedPosition(gridPos[0]), Quaternion.identity, puzzlePieceParent);
                            gridPos.RemoveAt(0);

                            break;
                        }
                }


                if (newPiece != null)
                {
                    newPiece.GetComponent<SlidePiece>().gm = GetComponent<GameManager>();
                    newPiece.GetComponent<SlidePiece>().emptySpace = emptySpace.GetComponent<Transform>();
                }
            }
        }

        // Level 2 Pattern
        void LevelTwoPattern()
        {
            emptySpace = Instantiate(emptySpacePrefab, GetFixedPosition(8), emptySpacePrefab.transform.rotation);
            emptySpace.GetComponent<EmptySpaceController>().gm = GetComponent<GameManager>();

            List<GameObject> levelPieces = currentLvlPrefabs._OfficePuzzlePieces.ToList();

            List<int> gridPos = new List<int>() { 1, 2, 3, 4, 7 };

            GameObject newPiece = null;
            for (int i = 1; i <= levelPieces.Count; i++)
            {
                switch (i)
                {
                    case 5:
                        {
                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(6), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    case 6:
                        {
                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(9), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    case 8:
                        {
                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(5), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    default:
                        {


                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(gridPos[0]), Quaternion.identity, puzzlePieceParent);
                            gridPos.RemoveAt(0);

                            break;
                        }
                }


                if (newPiece != null)
                {
                    newPiece.GetComponent<SlidePiece>().gm = GetComponent<GameManager>();
                    newPiece.GetComponent<SlidePiece>().emptySpace = emptySpace.GetComponent<Transform>();
                }
            }
        }

        // Level 3 Pattern
        void LevelThreePattern()
        {
            emptySpace = Instantiate(emptySpacePrefab, GetFixedPosition(8), emptySpacePrefab.transform.rotation);
            emptySpace.GetComponent<EmptySpaceController>().gm = GetComponent<GameManager>();

            List<GameObject> levelPieces = currentLvlPrefabs._OfficePuzzlePieces.ToList();

            List<int> gridPos = new List<int>() { 1, 2, 3, 4, 7 };

            GameObject newPiece = null;
            for (int i = 1; i <= levelPieces.Count; i++)
            {
                switch (i)
                {
                    case 5:
                        {
                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(6), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    case 6:
                        {
                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(9), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    case 8:
                        {
                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(5), Quaternion.identity, puzzlePieceParent);
                            break;
                        }
                    default:
                        {


                            newPiece = Instantiate(levelPieces[i - 1], GetFixedPosition(gridPos[0]), Quaternion.identity, puzzlePieceParent);
                            gridPos.RemoveAt(0);

                            break;
                        }
                }


                if (newPiece != null)
                {
                    newPiece.GetComponent<SlidePiece>().gm = GetComponent<GameManager>();
                    newPiece.GetComponent<SlidePiece>().emptySpace = emptySpace.GetComponent<Transform>();
                }
            }
        }

        // Create the Answer Prefabs
        void GetAnswerKeys(int level)
        {
            // Get the correct answer keys
            currentAnswerPrefabs = officeAnswerPrefabs[level - 1];

            // Randomize the oder
            currentAnswerPrefabs._OfficeAnswers = currentAnswerPrefabs._OfficeAnswers.OrderBy(x => new System.Random().Next()).ToArray();

            // Loop through the answer prefab
            for (int i = 0; i < answerPoses.Count; i++)
            {
                // Create the answer piece preefabs
                GameObject newAnswerPiece = Instantiate(currentAnswerPrefabs._OfficeAnswers[i], answerPoses[i].position, Quaternion.identity, answerPieceParent);

                // Tell them who is the GM
                newAnswerPiece.GetComponent<AnswerPiece>().gm = GetComponent<GameManager>();
            }
        }

        // Set the position of the answer pieces
        void SetAnswerPositions(int level, GameObject empty)
        {
            // List of X and Y coordinates
            List<Vector2> correctPos = new List<Vector2>();

            // Depending on the level, the correct positons are
            switch (level)
            {
                // Level 1
                case 1:
                    {
                        correctPos.Add(new Vector2(-1.375f, 2.875f));   // Top left
                        correctPos.Add(new Vector2(1.625f, -0.125f));   // Bottom right
                        break;
                    }
                // Level 2
                case 2:
                    {
                        correctPos.Add(new Vector2(1.625f, -0.125f));   // Bottom right
                        break;
                    }
                // Level 3
                case 3:
                    {
                        correctPos.Add(new Vector2(1.625f, -0.125f));   // Bottom right
                        break;
                    }
            }

            // Tell the empty square where the correct positon is
            empty.GetComponent<EmptySpaceController>().SetCorrectPositions(correctPos);

        }

        // Generate next level
        public void NextLevel()
        {
            currentLvl++;
            // Check if the parent exists
            if (puzzlePieceParent != null && answerPieceParent != null)
            {
                // Loops through each child and destorys them
                foreach (Transform child in puzzlePieceParent)
                {
                    GameObject.Destroy(child.gameObject);
                }

                foreach (Transform child in answerPieceParent)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }

            Destroy(emptySpace);

            if (currentLvl > 3)
            {
                // Exit Scene
                player.GetComponent<Torn.Interact.PlayerInteract>().anim.SetTrigger("FadeOut");
                //SceneManager.LoadScene("House");
                //print("Won!");
                StartCoroutine(Transition("House", 22.36f, -4.34f, -5, "FadeIn"));
            }
            else
            {
                solutionUnlockTimer += Time.timeSinceLevelLoad;
                solutionUnlocked = false;

                // GenerateGrid(++currentLvl);     // Recreate Grid with the new level
                Debug.Log ("Puzzle beat " + (currentLvl-1));
                GeneratePattern(currentLvl);
                
            }

            
        }

        // Set the piece as selected
        public void SetSelectedPiece(GameObject piece = null)
        {
            if (piece == null)
            {
                selectedPiece.GetComponentInParent<OfficePiece>().UnSelect();
            }

            selectedPiece = piece;
        }

        // Get the selected piece
        public GameObject GetSelectedPiece()
        {
            return selectedPiece;
        }

        public List<GameObject> GetPuzzlePieces()
        {
            List<GameObject> puzzlePieces = new List<GameObject>();
            foreach (Transform child in puzzlePieceParent)
            {
                puzzlePieces.Add(child.gameObject);
            }

            return puzzlePieces;
        }

        IEnumerator Transition(string level, float x, float y, float z, string trigger)
        {
            yield return new WaitForSecondsRealtime(1);
            player.GetComponent<Torn.Interact.PlayerInteract>().transform.position = new Vector3(x,y,z);
            SceneManager.LoadScene(level);
            player.GetComponent<Torn.Interact.PlayerInteract>().anim.SetTrigger("FadeIn");
        }

    }
}
