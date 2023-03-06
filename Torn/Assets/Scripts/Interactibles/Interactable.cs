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
        Door,
        Keys
    }

    public class Interactable : MonoBehaviour
    {
        public InteractType itemType;   // Type of the interactable

        public string collectableID = "";   // ID of the collectable

        public bool interactedWith;
        public string sceneName;

        private void Update() 
        {
            if (interactedWith)
            {
                transform.TransformPoint(15,15,15);
            }
        }

        public InteractType GetInteractType() { return itemType; }  // Return type of interactable

        public string GetCollectableID() { return collectableID; } // Return collectable ID
    }
}
