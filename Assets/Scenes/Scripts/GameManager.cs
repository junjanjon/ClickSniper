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

        private void Update()
        {
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