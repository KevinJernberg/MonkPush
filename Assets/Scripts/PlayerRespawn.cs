using StarterAssets;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 _respawnPos;

    [Tooltip("The Game Event that is called when player presses R")]
    private GameEvent onPuzzleReset;

    private StarterAssetsInputs _input;

    void Start()
    {
        _respawnPos = transform.position;
        _input = GetComponent<StarterAssetsInputs>();
    }

    public void Respawn()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = _respawnPos;
        GetComponent<CharacterController>().enabled = true;
    }
    
    public void SetRespawnPoint(Vector3 newRespawnPos)
    {
        _respawnPos = newRespawnPos;
    }
}
