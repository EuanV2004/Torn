using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(FindObjectOfType<Torn.Player.PlayerMovement>().transform.position.x, FindObjectOfType<Torn.Player.PlayerMovement>().transform.position.y, FindObjectOfType<Torn.Player.PlayerMovement>().transform.position.z);
    }
}
