using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private BoxCollider _conversationTriggerBox;
    void Start()
    {
        _conversationTriggerBox = GetComponentInChildren<BoxCollider>();
    }

    public void Interact()
    {
        _conversationTriggerBox.enabled = true;
    }

    public void Disengage()
    {
        _conversationTriggerBox.enabled = false;
    }
}
