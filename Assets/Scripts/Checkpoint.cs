using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 respawnPoint;
    [SerializeField] private AudioSource goatYell;
    [SerializeField] private AudioClip CheckpointAudio;

    private void Start()
    {
        respawnPoint = transform.GetChild(0).transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        goatYell.clip = CheckpointAudio;
        goatYell.Play();
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerRespawn>().SetRespawnPoint(respawnPoint);
        }
    }
}
