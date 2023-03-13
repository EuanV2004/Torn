using UnityEngine;

namespace Torn.Dialogues{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueSO thisDialogue;

        public DialogueSO ReturnCurrentDialogue() {
            return thisDialogue;
        }
    }
}