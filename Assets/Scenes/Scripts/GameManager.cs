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
                Instantiate(targets[currentTargetIndex].prefab,
                    new Vector3(-10, 0, 10),
                    Quaternion.identity);
                currentTargetIndex++;
            }
        }
    }
}