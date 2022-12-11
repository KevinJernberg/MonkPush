using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update

    private StarterAssetsInputs _input;

    private float _interactRange = 2;

    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.interact)
        {
            _input.interact = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, _interactRange, 512);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out NPCInteract NPC))
                {
                    NPC.GetComponent<NPCInteract>().Interact();
                }
            }
        }

    }
}
