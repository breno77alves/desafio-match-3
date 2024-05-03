using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gazeus.DesafioMatch3
{
    public class BoardVFX : MonoBehaviour
    {
        public static BoardVFX Instance { get; private set; }

        [SerializeField] private Transform _vfxParentPool;
        [SerializeField] private GameObject _destroyTileVFXPrefab;
        [SerializeField] private GameObject _glimmeringVFXPrefab;
        [SerializeField] private int _poolSize = 20;

        private List<GameObject> _destroyTileVFXPool = new List<GameObject>();
        private List<GameObject> _glimmeringVFXPool = new List<GameObject>();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            InitializeVFXPool();
        }

        private void InitializeVFXPool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                GameObject destroyTileVFX = Instantiate(_destroyTileVFXPrefab);
                GameObject glimmeringVFX = Instantiate(_glimmeringVFXPrefab);

                destroyTileVFX.transform.SetParent(_vfxParentPool);
                glimmeringVFX.transform.SetParent(_vfxParentPool);

                destroyTileVFX.SetActive(false);
                glimmeringVFX.SetActive(false);

                _destroyTileVFXPool.Add(destroyTileVFX);
                _glimmeringVFXPool.Add(glimmeringVFX);
            }
        }

        public GameObject GetDestroyTileVFX()
        {
            return GetAvailableVFX(_destroyTileVFXPool);
        }

        public GameObject GetGlimmeringVFX()
        {
            return GetAvailableVFX(_glimmeringVFXPool);
        }

        private GameObject GetAvailableVFX(List<GameObject> pool)
        {
            foreach (GameObject vfx in pool)
            {
                if (!vfx.activeSelf)
                {
                    vfx.SetActive(true);
                    return vfx;
                }
            }

            return null;
        }

    }
}
