using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Interact
{
    public class PlayerInteract : MonoBehaviour
    {
        public KeyCode interactKey = KeyCode.E;     // Saves the keycode of the interact key (Default is E)
        public KeyCode consumeKey = KeyCode.C;  // Saves the keycode of the consume key (Default is C)

        public Consumable pills = new Consumable();     // Reference to the Consumable Class
        public Consumable keys = new Consumable();
        public List<Interactable> collection = new List<Interactable>();    // List of collectable items

        public Collider2D itemCollider = new Collider2D();  // Holds the collider of the interactable
        public LayerMask floorLayer;

        public Animator animator;
        public Animator anim;
        public float wait;
        Scene currentScene;

        Scene scene;
        // Start is called before the first frame update
        void Start()
        {
            pills.AddConsumable(0);    // Player starts with 10 pills
            animator = GetComponent<Animator>();
            currentScene = SceneManager.GetActiveScene();
            
        }

        // Update is called once per frame
        void Update()
        {
            currentScene = SceneManager.GetActiveScene();
            InteractWith(itemCollider);     // Check every frame when the player has pressed the interact key

            ConsumePills();     // Check every frame when the player has pressed the consume key
        }

        // Called on entering a collider with isTrigger = true
        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Press {interactKey} to collect.");  // Notify the player the button to interact
            itemCollider = collision;   // Get the collider of the interactable
        }

        // Called on exiting a collider with isTrigger = true
        void OnTriggerExit2D(Collider2D collision)
        {
            // Check if the itemCollider is not null
            if (itemCollider != null)
            {
                itemCollider = null;    // Set it to null to prevent unwanted interaction
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == floorLayer) return;
            
            Debug.Log($"Press {interactKey} to collect.");  // Notify the player the button to interact
            itemCollider = collision.collider;   // Get the collider of the interactable
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            // Check if the itemCollider is not null
            if (itemCollider != null)
            {
                itemCollider = null;    // Set it to null to prevent unwanted interaction
            }
        }

        // Interact with items/environments
        public void InteractWith(Collider2D interacted)
        {
            if (Input.GetKeyDown(interactKey) && interacted != null && interacted.tag == "Interactable")  // Check if the player pressed the interact key and there are interactables
            {
                // Checks the type of interactable before determining what to do
                switch (interacted.GetComponent<Interactable>().GetInteractType())
                {
                    // If the interactable is collectable
                    case InteractType.Collectable:
                        {
                            collection.Add(interacted.GetComponent<Interactable>());    // Add collectable to the collection

                            Debug.Log($"{interacted.GetComponent<Interactable>().GetCollectableID()} Collected.");  // Notify the player
                            break;
                        }
                    // If the interactable is consumable
                    case InteractType.Consumable:
                        {
                            pills.AddConsumable();  // Add to pills counter
                            break;
                        }
                    // If the interactable is part of the environment
                    case InteractType.Puzzle:
                        {
                            interacted.GetComponent<Interactable>().interactedWith = true;

                            break;
                        }
                    
                    case InteractType.Audio:
                        {
                            anim.SetTrigger("FadeOut");
                            StartCoroutine(Transition("AudioPuzzle", -5.61f, -2.6f, -8.0f));
                            
                            break;
                        }

                    case InteractType.Clothes:
                        {
                            anim.SetTrigger("FadeOut");
                            StartCoroutine(Transition("ClothesPuzzle", 6.87f, -2.9f, -8f));
                            
                            break;
                        }
                        case InteractType.Logic:
                        {
                            anim.SetTrigger("FadeOut");
                            StartCoroutine(Transition("LogicPuzzle", 17.75f, -1, -5));
                            
                            break;
                        }
                        case InteractType.Water:
                        {
                            anim.SetTrigger("FadeOut");
                            StartCoroutine(Transition("WaterPuzzle", -16.22f, 10, -5));
                            
                            break;
                        }
                    case InteractType.Keys:
                        {
                            if (itemCollider.GetComponent<Interactable>().interactedWith == false)
                            {
                                keys.KeyCheckCounter();
                                itemCollider.GetComponent<Interactable>().interactedWith = true;  
                            }
                            break;
                        }
                }

                if (interacted.GetComponent<Interactable>().GetInteractType() == InteractType.Collectable || interacted.GetComponent<Interactable>().GetInteractType() == InteractType.Consumable)
                {
                    interacted.gameObject.SetActive(false);     // Set the game object to inactive (DO NOT delete because of collection list
                    itemCollider = null;    // Reset itemCollider
                }

            }
        }

        // Consume pills
        public void ConsumePills()
        {
            if (Input.GetKeyDown(consumeKey) && pills.GetCurrentCount() != 0)   // Check if the player has pressed the consume key and there are pills to consume
            {
                pills.UseConsumable();  // Consume pills
                animator.SetBool("eatPill", true);
                
                StartCoroutine(Pause(wait));
            }
        }

        private IEnumerator Pause(float pause)
        {
            anim.SetTrigger("FadeOut");
            yield return new WaitForSecondsRealtime(pause);
            animator.SetBool("eatPill", false);
            if (currentScene.name == "ClothesPuzzle")
            {
                this.transform.position = new Vector3(40.5f,-4.34f,-5f);
            }

            else if (currentScene.name == "AudioPuzzle")
            {
                this.transform.position = new Vector3(53.75f, -4.34f, -5f);
            }
            
            SceneManager.LoadScene("House");
            anim.SetTrigger("FadeIn");
        }

        private IEnumerator Transition(string level, float x, float y, float z)
        {
            yield return new WaitForSecondsRealtime(1);
            this.transform.position = new Vector3(x,y,z);
            SceneManager.LoadScene(level);
            anim.SetTrigger("FadeIn");
        }
    }
}
