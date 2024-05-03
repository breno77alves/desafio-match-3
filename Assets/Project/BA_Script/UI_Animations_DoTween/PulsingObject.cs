using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PulsingObject : MonoBehaviour
{
    [Header("Pulse Settings")]
    [SerializeField] float _pulseDuration = 1f;
    [SerializeField] float _scaleMultiplier = 1.2f;
    [SerializeField] Ease _scaleEaseTypeUp = Ease.OutQuad;
    [SerializeField] Ease _scaleEaseTypeDown = Ease.InQuad;

    private Vector3 _originalScale; 
    private Sequence _pulseSequence;
    private RectTransform _objectToPulse;

    void Start()
    {
        _objectToPulse = GetComponent<RectTransform>();

        _originalScale = _objectToPulse.localScale;

        _pulseSequence = DOTween.Sequence();

        Pulse();
    }

    void Pulse()
    {
        _pulseSequence.Append(_objectToPulse.DOScale(_originalScale * _scaleMultiplier, _pulseDuration / 2f).SetEase(_scaleEaseTypeUp));
        _pulseSequence.Append(_objectToPulse.DOScale(_originalScale, _pulseDuration / 2f).SetEase(_scaleEaseTypeDown));
        _pulseSequence.SetLoops(-1, LoopType.Restart);
    }

    void OnDestroy()
    {
            _pulseSequence.Kill();
    }
}
