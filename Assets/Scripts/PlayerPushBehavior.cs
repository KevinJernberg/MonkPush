using StarterAssets;
using UnityEngine;

namespace Work_In_Progress
{
    public class PlayerPushBehavior : MonoBehaviour
    {
        private StarterAssetsInputs _input;
        private Animator _animator;
    
        private RaycastHit _hitBlock;

        [SerializeField, Header("Push Values"), Tooltip("How much force a block will be pushed with")]
        private float PushForce = 4;
        
        private bool _hasAnimator;

        [SerializeField, Header("Sounds"), Tooltip("Pushing a Block")]
        private AudioSource audioSource;
        [SerializeField] private AudioClip PlayerPushSound;
        
        [SerializeField, Header("UI"), Tooltip("The image that displays when you may push a block")]
        private GameObject PushImage;

        private static readonly int Push = Animator.StringToHash("Push");

        void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
            _hasAnimator = TryGetComponent(out _animator);
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
                PushImage.SetActive(true);
                if (_input.push)
                {
                    _input.push = false;
                    if (_hasAnimator)
                    {
                        _animator.SetTrigger(Push);
                    }
                    if (PlayerPushSound != null)
                    {
                        audioSource.clip = PlayerPushSound;
                        audioSource.volume = 0.3f;
                        audioSource.Play();
                    }
                    _hitBlock.transform.gameObject.GetComponent<BlockPusher>().StartPush(_hitBlock.normal, PushForce);
                }
            }
            else
            {
                PushImage.SetActive(false);
                _input.push = false;
            }
        }
    }
}
