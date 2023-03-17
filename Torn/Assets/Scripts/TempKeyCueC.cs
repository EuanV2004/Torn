using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Torn.Dialogues;
using Torn.Player;

public class TempKeyCueC : MonoBehaviour
{
    [SerializeField] private GameObject keyCue;
    [SerializeField] private DialogueSO dialogue;
    private bool hasPassedOnce = false;
    private PlayerDialogueManager playerDialogueManager;

    private void Start() {
        playerDialogueManager = FindObjectOfType<PlayerDialogueManager>();
    }

    private void Update() {
        if (!hasPassedOnce) return;

        if (Input.GetKeyDown(KeyCode.E)) {
            keyCue.SetActive(true);
            print("C");
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            keyCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !hasPassedOnce) {
            playerDialogueManager.SetDialogue(dialogue);
            hasPassedOnce = true;
        }
    }
}
