using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Torn.Interact
{
    // Hold the different types of interactables
    public enum InteractType
    {
        Collectable,
        Consumable,
        Environment,
        Puzzle
    }

    public class Interactable : MonoBehaviour
    {
        public InteractType itemType;   // Type of the interactable

        public string collectableID = "";   // ID of the collectable

        /*// Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }*/

        public InteractType GetInteractType() { return itemType; }  // Return type of interactable

        public string GetCollectableID() { return collectableID; } // Return collectable ID
    }
}
