using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TargetPrefabInfo[] targets;
        
        [Serializable]
        struct TargetPrefabInfo
        {
            public GameObject prefab;
            public float time;
        }

        private int _currentTargetIndex = 0;
        private float _gameTime = 30f;

        private void Start()
        {
            GameObject.Find("RetryButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }

        private void Update()
        {
            _gameTime -= Time.deltaTime;
            if (_gameTime < 0)
            {
                GameObject.Find("TimeUpText").GetComponent<Text>().enabled = true;
                GetComponent<BallShot>().enabled = false;
                return;
            }
            if (targets.Length <= _currentTargetIndex)
            {
                return;
            }

            targets[_currentTargetIndex].time -= Time.deltaTime;

            if (targets[_currentTargetIndex].time < 0)
            {
                var y = UnityEngine.Random.Range(-4, 2);
                var z = UnityEngine.Random.Range(2, 8);
                Instantiate(targets[_currentTargetIndex].prefab,
                    new Vector3(-25, y, z),
                    Quaternion.identity);
                _currentTargetIndex++;
            }
        }
    }
}