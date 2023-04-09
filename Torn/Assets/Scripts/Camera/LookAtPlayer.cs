using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField] float posZ;
    void Update()
    {
        transform.position = new Vector3(FindObjectOfType<Torn.Interact.PlayerInteract>().transform.position.x + posX, FindObjectOfType<Torn.Interact.PlayerInteract>().transform.position.z + posZ);
    }
}
