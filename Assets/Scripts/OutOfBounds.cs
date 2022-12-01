using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yep");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player");
            other.gameObject.GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
