using UnityEngine;

namespace Torn.Dialogues {
[CreateAssetMenu(fileName = "New dialogue", menuName = "Custom Objects/New dialogue", order = 0)]
    public class DialogueSO : ScriptableObject
    {
        public DialogueContainer[] dialogues;

        public int ReturnDialogueLength() {
            return dialogues.Length;
        }

        public DialogueContainer[] ReturnDialogueArray() {
            return dialogues;
        }
    }
}