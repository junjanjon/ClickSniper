using UnityEngine;

namespace Scenes.Scripts
{
    public class BallDelete : MonoBehaviour
    {
        [SerializeField]
        private float destroyTime;
        void Update()
        {
            destroyTime -= Time.deltaTime;

            if (destroyTime < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
