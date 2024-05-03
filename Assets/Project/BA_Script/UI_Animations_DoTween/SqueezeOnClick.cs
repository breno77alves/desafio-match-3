using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SqueezeOnClick : MonoBehaviour
{
    [SerializeField] float _animationDuration = 0.15f;
    [SerializeField] float _squeezeScale = 0.9f;

    private Button _button;
    private Vector3 _originalScale;

    void Start()
    {
        _button = GetComponent<Button>();

        _originalScale = _button.transform.localScale;
    }

    public void SqueezeAnimation()
    {
        _button.transform.DOScale(_originalScale * _squeezeScale, _animationDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                _button.transform.DOScale(_originalScale, _animationDuration)
                    .SetEase(Ease.OutQuad);
            });
    }
}
