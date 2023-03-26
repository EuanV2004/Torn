using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Torn.Interact
{
    // Hold the different types of interactables
    public enum InteractType
    {
        Collectable,
        Consumable,
        Environment,
        Puzzle,
        Audio,
        Clothes,
        Logic,
        Water,
        Door,
        Keys
    }

    public class Interactable : MonoBehaviour
    {
        public InteractType itemType;   // Type of the interactable

        public string collectableID = "";   // ID of the collectable

        public bool interactedWith;
        public string sceneName;
        public Animator animator;

        private void Start() 
        {
            animator = GetComponent<Animator>();
        }

        private void Update() 
        {
            if (interactedWith)
            {
                transform.TransformPoint(15,15,15);
            }
        }

        public InteractType GetInteractType() { return itemType; }  // Return type of interactable

        public string GetCollectableID() { return collectableID; } // Return collectable ID

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (animator != null)
            {
                if (collision.CompareTag("Player") && !gameObject.name.Contains("scale")) // Change "Player" to the tag of the object you want to check for
                {
                    if (!interactedWith)
                    {
                        animator.SetBool("InRange", true); // Change "ExitTrigger" to the name of the trigger parameter you added to your animation state
                    }
                    else if (interactedWith)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (animator != null && !gameObject.name.Contains("scale"))
            {
                if (collision.CompareTag("Player")) // Change "Player" to the tag of the object you want to check for
                {
                    animator.SetBool("InRange", false); // Change "ExitTrigger" to the name of the trigger parameter you added to your animation state
                }
            }
        }
    }
}
