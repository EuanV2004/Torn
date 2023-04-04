using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    [SerializeField] GameObject image;
    Torn.Interact.PlayerInteract player;

    private void Start() 
    {
        player = FindObjectOfType<Torn.Interact.PlayerInteract>();
    }

    public void Disable()
    {
        image.SetActive(false);
    }

    public void LockMovement()
        {
            player.LockMovement();
        }

        public void UnlockMovement()
        {
            player.UnlockMovement();
        }   
}
