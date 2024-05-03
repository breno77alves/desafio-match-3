using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] Vector3 _rotationAxis = Vector3.forward;
    [SerializeField] float _animationDuration = 1f;
    [SerializeField] float _animationInterval = 0f;

    private RectTransform _targetRectTransform;
    private Sequence _sequence;

    private void Start()
    {
        _targetRectTransform = GetComponent<RectTransform>();
        _sequence = DOTween.Sequence();
        StartRotation();
    }

    private void StartRotation()
    {
        _sequence.Append(_targetRectTransform.DORotate(_rotationAxis * 360f, _animationDuration, RotateMode.FastBeyond360));

        if (_animationInterval > 0f)
        {
            _sequence.AppendInterval(_animationInterval);
        }

        _sequence.SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}
