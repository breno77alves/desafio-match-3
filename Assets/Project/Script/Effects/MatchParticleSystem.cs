using UnityEngine;
using Gazeus.DesafioMatch3.Core;
using System.Collections.Generic;

namespace Gazeus.DesafioMatch3.Particle
{
    public class MatchParticleSystem : MonoBehaviour
    {
        public GameObject prefabToSpawn;

        // Method to spawn prefab at a given position
        public void SpawnPrefab(Vector3 position)
        {
            Instantiate(prefabToSpawn, position, Quaternion.identity);
        }
    }
}