using StarterAssets;
using UnityEngine;

namespace Work_In_Progress
{
    public class PlayerPushBehavior : MonoBehaviour
    {
        private StarterAssetsInputs _input;
    
        private RaycastHit _hitBlock;

        [SerializeField, Header("Push Values"), Tooltip("How much force a block will be pushed with")]
        private float PushForce = 4;

        [SerializeField, Header("Sounds"), Tooltip("Pushing a Block")]
        private AudioClip PlayerPushSound;

        void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            // Character push check ray
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 1f;
            Vector3 pushRay = transform.position + new Vector3(0, 1, 0);
            Debug.DrawRay(pushRay, forward, Color.green);
            if (Physics.Raycast(pushRay, transform.TransformDirection(Vector3.forward), out _hitBlock, 1f, 64))
            {
                if (_input.push)
                {
                    _input.push = false;
                    if (PlayerPushSound != null)
                    {
                        AudioSource.PlayClipAtPoint(PlayerPushSound, transform.position);
                    }
                    _hitBlock.transform.gameObject.GetComponent<BlockPusher>().StartPush(_hitBlock.normal, PushForce);
                }
            }
            else
            {
                _input.push = false;
            }
        }
    }
}
