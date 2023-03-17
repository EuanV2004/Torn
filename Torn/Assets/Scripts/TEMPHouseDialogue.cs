using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Torn.Player;
using Torn.Dialogues;

public class TEMPHouseDialogue : MonoBehaviour
{
    [SerializeField] private DialogueSO dialogue;
    private PlayerDialogueManager playerDialogueManager;

    private void Start() {
        playerDialogueManager = FindObjectOfType<PlayerDialogueManager>();

        playerDialogueManager.SetDialogue(dialogue);
    }
}