using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Torn.Interact
{
    public class Consumable
    {
        public int maxItemStack = 99;   // Maximum stack of the item

        public int itemCounter;     // Counter of the item
        public int keyCounter;

        // Get the current amount of the consumable
        public int GetCurrentCount() { return itemCounter; }
        public int GetCurrentKeyCount() {return keyCounter; }

        // Add consumable to the player. Default is 1;
        public void AddConsumable(int n = 1)
        {
            itemCounter += n;   // Add to the counter

            Debug.Log($"Pills Left: {GetCurrentCount()}");  // Display to the player
        }

        public void KeyCheckCounter(int i = 1) 
        {
            keyCounter += i;
            if (keyCounter >= 5)
            {
                keyCounter = 5;
            }
            
            Debug.Log($"You have checked {GetCurrentKeyCount()}/5 locations");
        }

        // Player uses consumable
        public void UseConsumable()
        {
            // Check if the item counter can be reduced to 0
            if (itemCounter > 0)
            {
                itemCounter--;  // Remove 1 from counter
            }
            else
            {
                itemCounter = 0;    // Set to a minimum of 0
            }

            Debug.Log($"Pills Left: {GetCurrentCount()}");  // Notify to the player
        }
    }
}
