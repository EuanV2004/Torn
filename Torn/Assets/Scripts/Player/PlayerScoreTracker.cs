using UnityEngine;
using Torn.Managers;

namespace Torn.Player
{
    public class PlayerScoreTracker : MonoBehaviour
    {
        // Making this serializable only temporarily. This will be private in the actual version of the script.
        [SerializeField] private int playerScore;

        private EndingManager endingManager;

        private void Start() {
            endingManager = FindObjectOfType<EndingManager>();
        }

        private void Update() {
            playerScore = endingManager.GetPlayerScore();

            if (Input.GetKeyDown(KeyCode.P)) {
                endingManager.IncreasePlayerScore(); // Debugging purposes only
            }

            if (Input.GetKeyDown(KeyCode.F)) {
                endingManager.ChooseEnding(); // Debugging puproses only
            }
        }
    }
}