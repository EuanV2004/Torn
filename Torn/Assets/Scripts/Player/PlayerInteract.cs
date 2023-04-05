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
        public bool hasKey;
        bool canMove = true;
        [SerializeField] int puzzleCount = 0;
        [SerializeField] int keyCount = 0;
        [SerializeField] bool playedAudioPuzzle;
        [SerializeField] bool playedClothesPuzzle;
        [SerializeField] bool playedLogicPuzzle;
        [SerializeField] bool playedWaterPuzzle;
        [SerializeField] GameObject keyAnimationImage;
        [SerializeField] GameObject keyAnimation;
        Animator keyAnim;
        Scene currentScene;

        Scene scene;
        // Start is called before the first frame update
        void Start()
        {
            pills.AddConsumable(0);    // Player starts with 10 pills
            animator = GetComponent<Animator>();
            currentScene = SceneManager.GetActiveScene();
            if (keyAnimation != null)
            {
                keyAnim = keyAnimation.GetComponent<Animator>();
            }
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
                            if (itemCollider.GetComponent<Interactable>().interactedWith == false)
                            {
                                anim.SetTrigger("FadeOut");
                                StartCoroutine(Transition("AudioPuzzle", -5.61f, -2.6f, -8.0f, "FadeIn"));
                                itemCollider.GetComponent<Interactable>().interactedWith = true; 
                                itemCollider.gameObject.transform.position = new Vector3(500, 500, 500);
                                playedAudioPuzzle = true;
                                puzzleCount++;
                            }
                            
                            break;
                        }

                    case InteractType.Clothes:
                        {
                            if (itemCollider.GetComponent<Interactable>().interactedWith == false)
                            {
                                anim.SetTrigger("FadeOut");
                                StartCoroutine(Transition("ClothesPuzzle", 6.87f, -2.9f, -8f, "FadeIn"));
                                itemCollider.GetComponent<Interactable>().interactedWith = true; 
                                itemCollider.gameObject.transform.position = new Vector3(500, 500, 500);
                                playedClothesPuzzle = true;
                                puzzleCount++;
                            }
                            
                            break;
                        }
                        case InteractType.Logic:
                        {
                            if (itemCollider.GetComponent<Interactable>().interactedWith == false)
                            {
                                anim.SetTrigger("FadeOut");
                                StartCoroutine(Transition("LogicPuzzle", 17.75f, -1, -5, "FadeIn"));
                                itemCollider.GetComponent<Interactable>().interactedWith = true; 
                                itemCollider.gameObject.transform.position = new Vector3(500, 500, 500);
                                playedLogicPuzzle = true;
                                puzzleCount++;
                            }
                            
                            break;
                        }
                        case InteractType.Water:
                        {
                            if (itemCollider.GetComponent<Interactable>().interactedWith == false)
                            {
                                anim.SetTrigger("FadeOut");
                                StartCoroutine(Transition("WaterPuzzle", -16.22f, 10, -5, "FadeIn"));
                                itemCollider.GetComponent<Interactable>().interactedWith = true; 
                                itemCollider.gameObject.transform.position = new Vector3(500, 500, 500);
                                playedWaterPuzzle = true;
                                puzzleCount++;
                            }
                            
                            break;
                        }
                        case InteractType.Keys:
                        {
                            if (itemCollider.GetComponent<Interactable>().interactedWith == false)
                            {
                                keys.KeyCheckCounter();
                                if (itemCollider.GetComponent<Interactable>().GetIsKey() == true)
                                {
                                    hasKey = true;
                                    keyAnimationImage.SetActive(true);
                                    keyAnim.SetTrigger("Key");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsSock() == true)
                                {
                                    keyAnimationImage.SetActive(true);
                                    keyAnim.SetTrigger("Sock");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsCoin() == true)
                                {
                                    keyAnimationImage.SetActive(true);
                                    keyAnim.SetTrigger("Coins");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsChicken() == true)
                                {
                                    keyAnimationImage.SetActive(true);
                                    keyAnim.SetTrigger("Chicken");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsToothpaste() == true)
                                {
                                    keyAnimationImage.SetActive(true);
                                    keyAnim.SetTrigger("Toothpaste");
                                }
                                itemCollider.GetComponent<Interactable>().interactedWith = true;  
                                keyCount++;
                                itemCollider.gameObject.transform.position = new Vector3(500, 500, 500);
                            }
                            break;
                        }
                        case InteractType.Door:
                        {
                            if (hasKey)
                            {
                                anim.SetTrigger("FadeOut");
                                StartCoroutine(Transition("EndHall", 500f, -4.34f, -5f, "FadeIn"));
                            }
                            break;
                        }
                        case InteractType.EndingCollect:
                        {
                            if (itemCollider.GetComponent<Interactable>().GetIsBear() == true)
                                {
                                    animator.SetTrigger("Bear");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsPicture() == true)
                                {
                                    animator.SetTrigger("Picture");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsBook() == true)
                                {
                                    animator.SetTrigger("Book");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsSoap() == true)
                                {
                                    animator.SetTrigger("Soap");
                                }

                                if (itemCollider.GetComponent<Interactable>().GetIsCoat() == true)
                                {
                                    
                                }
                            FindObjectOfType<Torn.Managers.EndingManager>().IncreasePlayerScore();
                            itemCollider.gameObject.transform.position = new Vector3(500, 500, 500);
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
                this.transform.position = new Vector3(31.59f,-4.34f,-5f);
            }

            else if (currentScene.name == "AudioPuzzle")
            {
                this.transform.position = new Vector3(55.25f, -4.34f, -5f);
            }
            
            SceneManager.LoadScene("House");
            anim.SetTrigger("FadeIn");
        }

        private IEnumerator Transition(string level, float x, float y, float z, string trigger)
        {
            yield return new WaitForSecondsRealtime(1);
            this.transform.position = new Vector3(x,y,z);
            SceneManager.LoadScene(level);
            anim.SetTrigger("FadeIn");
        }

        public int GetPuzzleCount()
        {
            return puzzleCount;
        }

        public int GetKeyCount()
        {
            return keyCount;
        }

        public bool GetPlayedAudioPuzzle()
        {
            return playedAudioPuzzle;
        }

        public bool GetPlayedClothesPuzzle()
        {
            return playedClothesPuzzle;
        }

        public bool GetPlayedLogicPuzzle()
        {
            return playedLogicPuzzle;
        }

        public bool GetPlayedWaterPuzzle()
        {
            return playedWaterPuzzle;
        }

        public bool GetCanMove()
        {
            return canMove;
        }

        public void SetCanMoveTrue()
        {
            canMove = true;
        }

        public void SetCanMoveFalse()
        {
            canMove = false;
        }

        public void LockMovement()
        {
            canMove = false;
        }

        public void UnlockMovement()
        {
            canMove = true;
        }
    }
}
