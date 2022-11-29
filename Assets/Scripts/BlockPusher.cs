using System;
using UnityEngine;

namespace Work_In_Progress
{
    public class BlockPusher : MonoBehaviour
    {
        private Vector3 _PushDirection;
        private float _pushForce;

        private bool _moving;

        private float _collisionEdgeDistance;

        // Update is called once per frame
        void Update()
        {
            if (_moving)
            {
                transform.position += _PushDirection * _pushForce * Time.deltaTime;
                Vector3 collisionCheckOriginPoint = new Vector3(transform.position.x, transform.lossyScale.y * 0.5f + 0.05f, transform.position.z);
                if (Physics.Raycast(transform.position, _PushDirection, _collisionEdgeDistance))
                {
                    _moving = false;
                    transform.position = new Vector3(MathF.Round(transform.position.x * 2) / 2,
                        MathF.Round(transform.position.y * 2) /2, MathF.Round(transform.position.z * 2) / 2);
                }
            }
        }

        public void Push(Vector3 direction, float force)
        {
            _PushDirection = direction * -1f;
            _pushForce = force;
            _moving = true;
            if (_PushDirection.x == 0) // Moving in Z axis
            {
                _collisionEdgeDistance = transform.localScale.z / 2f;
            }
            else // Moving in X axis
            {
                _collisionEdgeDistance = transform.localScale.x / 2f;
            }
        }
    }
}
