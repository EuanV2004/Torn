using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Torn.Stack
{
    public class StackBuilder : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> stackPrefabs = new List<GameObject>();     // List of stack prefabs

        [SerializeField]
        GameObject resumePrefab, tablePrefab;    // Resume prefab

        [SerializeField]
        int stackSize, minStack, maxStack;  // Stack variables for the size of stack to create, minimum stack size and maximum stack size

        [SerializeField]
        int resumePlacement;    // Where the resumes should spawn in the stack

        [SerializeField]
        bool hardMode;

        int itemSelected;   // Which prefab to select
        bool newBottom, bottomSpawned;

        Vector3 placement;  // Position to spawn the prefabs

        // Start is called before the first frame update
        void Start()
        {
            placement = transform.position;     // Set the inital placement to the position of the stack manager

            stackSize = Random.Range(minStack, maxStack);   // Randomize stack size

            // Radomly select where to place the resume
            resumePlacement = Random.Range(hardMode ? 0 : 1, stackSize - 1);  // NOTE: hardmode on will make the minimum placement at the bottom of the stack

            BuildStack();   // Build the stack
        }

        void BuildStack()
        {
            // Loop until the stack is built
            for (int i = 0; i < stackSize; i++)
            {
                GameObject temp = null;

                // If the placement is where the resume should be, place the resume
                if (i == resumePlacement)
                {
                    if (hardMode)
                    {
                        resumePrefab.GetComponent<ObjectPull>().HardmodeOn(hardMode);
                    }
                    resumePrefab.GetComponent<ObjectPull>().SetForceMuliplier((stackSize - resumePlacement));

                    placement.y += 0.1f; // Adjust the y position to account for the thickness of the resume
                    Instantiate(resumePrefab, placement, transform.rotation, this.transform);   // Create the resume in the correct position.

                    placement.y += 0.1f; // Adjust for the next item in the stack
                }
                else
                {
                    itemSelected = Random.Range(0, stackPrefabs.Count);     // Randomly select a stack item prefab

                    switch (itemSelected)
                    {
                        // Paper Prefab
                        case 0:
                            {
                                placement.y += 0.1f;
                                temp = Instantiate(stackPrefabs[itemSelected], placement, transform.rotation, this.transform);

                                placement.y += 0.1f;
                                break;
                            }
                        // Thin Book Prefab
                        case 1:
                            {
                                placement.y += 0.2f;
                                temp = Instantiate(stackPrefabs[itemSelected], placement, transform.rotation, this.transform);

                                placement.y += 0.2f;
                                break;
                            }
                        // Thick Book Prefab
                        case 2:
                            {
                                placement.y += 0.25f;
                                temp = Instantiate(stackPrefabs[itemSelected], placement, transform.rotation, this.transform);

                                placement.y += 0.25f;
                                break;
                            }
                    }   // END OF SWITCH
                }   // END IF ELSE

                if (i == 0 && temp != null || newBottom)
                {
                    temp.name += " [Bottom]";
                    temp.tag = "BottomItem";

                    newBottom = false;
                    bottomSpawned = true;
                }
                else if (temp == null && !bottomSpawned)
                {
                    newBottom = true;
                }

            }   // END OF FOR LOOP
        }
    }
}
