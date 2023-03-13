using UnityEngine;

namespace Torn.Dialogues {
    [RequireComponent(typeof(AudioSource))]
    public class PlayerDialogueManager : MonoBehaviour
    {
        private DialogueSO newDialogue;
        private AudioSource audioSource;
        private DialogueContainer[] currentDialogues;
        private int currentDialogueIndex = 0;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update() {
            if (!newDialogue) return;

            if (Input.GetKeyDown(KeyCode.E) && currentDialogueIndex < newDialogue.ReturnDialogueLength()) {
                ParseDialogueObject();
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Dialogue")) {
                newDialogue = other.GetComponent<DialogueTrigger>().ReturnCurrentDialogue();
                currentDialogues = newDialogue.ReturnDialogueArray();
                currentDialogueIndex = 0;
            }
        }

        private void ParseDialogueObject() {
            print(currentDialogues[currentDialogueIndex].dialogueText);
            audioSource.PlayOneShot(currentDialogues[currentDialogueIndex].dialogueAudio);
            currentDialogueIndex++;
        }
    }
}