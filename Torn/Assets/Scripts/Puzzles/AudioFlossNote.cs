using UnityEngine;

namespace Torn.Puzzles
{
    public enum Notes {E, G, A, B, D}

    public class AudioFlossNote : MonoBehaviour
    {
        [SerializeField] private Notes currentNote;

        public Notes GetCurrentNote() {
            return currentNote;
        }
    }
}