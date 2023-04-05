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
        transform.position = new Vector3(FindObjectOfType<Torn.Player.PlayerMovement>().transform.position.x + posX, FindObjectOfType<Torn.Player.PlayerMovement>().transform.position.y + posY, FindObjectOfType<Torn.Player.PlayerMovement>().transform.position.z + posZ);
    }
}
