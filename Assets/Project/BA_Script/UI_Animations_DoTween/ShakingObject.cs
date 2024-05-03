using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakingObject : MonoBehaviour
{
    [SerializeField] Vector2 _shakeStrength = new Vector2(10f, 10f);
    [SerializeField] float _animationDuration = 0.5f;
    [SerializeField] float animationInterval = 0f;
    [SerializeField] int _vibrationNumber = 10;
    [SerializeField] float _randomness = 90f;
    [SerializeField] bool _fadeOut = true;

    private RectTransform _targetRectTransform;
    private Sequence _sequence;

    private void Start()
    {
        _targetRectTransform = GetComponent<RectTransform>();
        _sequence = DOTween.Sequence();
        StartShake();
    }

    private void StartShake()
    {
        _sequence.Append(_targetRectTransform.DOShakePosition(_animationDuration, _shakeStrength, _vibrationNumber, _randomness, _fadeOut));

        if (animationInterval > 0f)
        {
            _sequence.AppendInterval(animationInterval);
        }

        _sequence.SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}
