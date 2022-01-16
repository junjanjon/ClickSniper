using System;
using UnityEngine;

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

        private int currentTargetIndex = 0;
        private float _gameTime = 30f;

        private void Update()
        {
            _gameTime -= Time.deltaTime;
            if (_gameTime < 0)
            {
                GameObject.Find("TimeUpText").GetComponent<UnityEngine.UI.Text>().enabled = true;
                GetComponent<BallShot>().enabled = false;
                return;
            }
            if (targets.Length <= currentTargetIndex)
            {
                return;
            }

            targets[currentTargetIndex].time -= Time.deltaTime;

            if (targets[currentTargetIndex].time < 0)
            {
                var y = UnityEngine.Random.Range(-4, 2);
                var z = UnityEngine.Random.Range(2, 8);
                Instantiate(targets[currentTargetIndex].prefab,
                    new Vector3(-25, y, z),
                    Quaternion.identity);
                currentTargetIndex++;
            }
        }
    }
}