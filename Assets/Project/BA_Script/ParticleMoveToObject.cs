using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ParticleMoveToObject : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;
    [SerializeField] RectTransform _startLocation;
    [SerializeField] TextMeshProUGUI _coinsText;
    [SerializeField] RectTransform _endLocation;
    [SerializeField] float _delayBetweenPrefabs = 0.3f;
    [SerializeField] float _moveDuration = 0.2f;
    [SerializeField] float _spawnRangeX = 0.5f;
    [SerializeField] float _spawnRangeY = 0.5f;

    private int _coinAmount = 0;

    public void SpawnCoins()
    {
        StartCoroutine(AnimatePrefabs());
    }

    IEnumerator AnimatePrefabs()
    {
        foreach (GameObject prefab in _prefabs)
        {
            prefab.SetActive(true);

            float randomOffsetX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomOffsetY = Random.Range(-_spawnRangeY, _spawnRangeY);

            Vector3 spawnPosition = _startLocation.position + new Vector3(randomOffsetX, randomOffsetY, 0f);
            prefab.transform.position = spawnPosition;
            prefab.transform.localScale = Vector3.zero;

            prefab.transform.DOScale(Vector3.one, _moveDuration);

            yield return new WaitForSeconds(_delayBetweenPrefabs);
        }

        yield return new WaitForSeconds(_moveDuration);

        foreach (GameObject prefab in _prefabs)
        {
            prefab.transform.DOMove(_endLocation.position, _moveDuration);
        }

        yield return new WaitForSeconds(_moveDuration);

        foreach (GameObject prefab in _prefabs)
        {
            prefab.SetActive(false);
            _coinAmount += 50;
            _coinsText.text = _coinAmount.ToString();
        }
    }
}
