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
        Keys,
        EndingCollect
    }

    public class Interactable : MonoBehaviour
    {
        public InteractType itemType;   // Type of the interactable

        [Header("Keys")]

        [SerializeField] bool isKey;
        [SerializeField] bool isCoin;
        [SerializeField] bool isSock;
        [SerializeField] bool isToothpaste;
        [SerializeField] bool isChicken;

        [Header("EndingStuff")]

        [SerializeField] bool isBear;
        [SerializeField] bool isSoap;
        [SerializeField] bool isCoat;
        [SerializeField] bool isBook;
        [SerializeField] bool isPicture;

        [Header("Button")]
        [SerializeField] GameObject cKey;

        [Header("Interact")]

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
                if (cKey != null)
                {
                    cKey.SetActive(true);
                }
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
                        gameObject.transform.position = new Vector3(500, 500, 500);                   
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

                else if (interactedWith)
                {
                    gameObject.transform.position = new Vector3(500, 500, 500);                   
                }
            }
        }

        public bool GetIsKey()
        {
            return isKey;
        }

        public bool GetIsSock()
        {
            return isSock;
        }

        public bool GetIsCoin()
        {
            return isCoin;
        }

        public bool GetIsChicken()
        {
            return isChicken;
        }

        public bool GetIsToothpaste()
        {
            return isToothpaste;
        }


        public bool GetIsBear()
        {
            return isBear;
        }

        public bool GetIsSoap()
        {
            return isSoap;
        }

        public bool GetIsCoat()
        {
            return isCoat;
        }

        public bool GetIsBook()
        {
            return isBook;
        }

        public bool GetIsPicture()
        {
            return isPicture;
        }
    }
}
