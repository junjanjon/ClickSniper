using UnityEngine;

namespace Scenes.Scripts
{
    public class TargetMove : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        private Rigidbody _rigidbody;
        private float _time = 0.1f;
        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (0 < _time)
            {
                _time -= Time.deltaTime;
            }
            _rigidbody.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed);
        }
    }
}
