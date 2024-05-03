using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeObject : MonoBehaviour
{
    [SerializeField] float _fadeInValue = 1f;
    [SerializeField] float _fadeOutValue = 0f;
    [SerializeField] float _duration = 1f;

    private Image _image;
    private Sequence _sequence;

    private void Start()
    {
        _image = GetComponent<Image>();
        _sequence = DOTween.Sequence();
        FadeInAndOut();
    }

    public void FadeInAndOut()
    {
        _sequence.Append(_image.DOFade(_fadeInValue, _duration));
        _sequence.Append(_image.DOFade(_fadeOutValue, _duration));
        _sequence.SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}

