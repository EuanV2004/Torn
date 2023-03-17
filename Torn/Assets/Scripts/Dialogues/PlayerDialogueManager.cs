using UnityEngine;
using Torn.UI;

namespace Torn.Dialogues {
    [RequireComponent(typeof(AudioSource))]
    public class PlayerDialogueManager : MonoBehaviour
    {
        private DialogueSO newDialogue;
        private AudioSource audioSource;
        private DialogueContainer[] currentDialogues;
        private int currentDialogueIndex = 0;
        private DialogueUIManager dialogueUIManager;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
            dialogueUIManager = FindObjectOfType<DialogueUIManager>();
        }

        private void Update() {
            if (!newDialogue) return;

            if (Input.GetKeyDown(KeyCode.E) && currentDialogueIndex == newDialogue.ReturnDialogueLength()) {
                dialogueUIManager.SetObjectInactive();
            }

            if (Input.GetKeyDown(KeyCode.E) && currentDialogueIndex < newDialogue.ReturnDialogueLength()) {
                ParseDialogueObject();
            }
        }

        public void SetDialogue(DialogueSO dialogue) {
            newDialogue = dialogue;
            currentDialogues = newDialogue.ReturnDialogueArray();
            currentDialogueIndex = 0;
            ParseDialogueObject();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Dialogue")) {
                newDialogue = other.GetComponent<DialogueTrigger>().ReturnCurrentDialogue();
                currentDialogues = newDialogue.ReturnDialogueArray();
                currentDialogueIndex = 0;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Dialogue")) {
                dialogueUIManager.SetObjectInactive();
            }
        }

        private void ParseDialogueObject() {
            if (!dialogueUIManager) return;

            dialogueUIManager.SetObjectActive();
            dialogueUIManager.SetText(currentDialogues[currentDialogueIndex].dialogueText);

            if (currentDialogues[currentDialogueIndex].dialogueAudio != null) {
                audioSource.PlayOneShot(currentDialogues[currentDialogueIndex].dialogueAudio);
            }

            currentDialogueIndex++;
        }
    }
}