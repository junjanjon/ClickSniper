using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scripts
{
    public class ScoreCount : MonoBehaviour
    {
        public int score = 0;
        [SerializeField] private Text scoreText;

        private void Update()
        {
            scoreText.text = $"SCORE: {score}";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("ScorePoint"))
            {
                Destroy(other.gameObject);
                score++;
            }
        }
    }
}
