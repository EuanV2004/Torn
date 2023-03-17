using UnityEngine;
using TMPro;

namespace Torn.UI {
    public class DialogueUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private TextMeshProUGUI dialogueText;

        private void Start() {
            dialogueBox.SetActive(false);
        }

        public void SetObjectActive() {
            dialogueBox.SetActive(true);
        }

        public void SetObjectInactive() {
            dialogueBox.SetActive(false);
        }

        public void SetText(string text) {
            dialogueText.text = text;
        }
    }
}