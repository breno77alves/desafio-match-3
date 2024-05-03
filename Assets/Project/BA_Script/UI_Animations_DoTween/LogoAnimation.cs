using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LogoAnimation : MonoBehaviour
{
    [Header("Letters")]
    [SerializeField] RectTransform _M;
    [SerializeField] RectTransform _A;
    [SerializeField] RectTransform _T;
    [SerializeField] RectTransform _C;
    [SerializeField] RectTransform _H;

    [Header("Animation Durations")]
    [SerializeField] float _animationDuration = 0.5f;
    [SerializeField] float _delayBetweenPairs = 1.5f;
    [SerializeField] float _delayBeforeStart = 1.5f;
    [SerializeField] float _delayBeforeRestart = 2f;

    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence();
        StartAnimation();
    }

    private void StartAnimation()
    {
        
        _sequence.AppendInterval(_delayBeforeStart);

        #region Move M and A
        _sequence.Append(_M.DOAnchorPos(_A.anchoredPosition, _animationDuration));
        _sequence.Join(_A.DOAnchorPos(_M.anchoredPosition, _animationDuration));

        _sequence.AppendInterval(_delayBetweenPairs);

        _sequence.Append(_M.DOAnchorPos(_M.anchoredPosition, _animationDuration));
        _sequence.Join(_A.DOAnchorPos(_A.anchoredPosition, _animationDuration));
        #endregion

        _sequence.AppendInterval(Random.Range(0.2f, 0.4f));

        #region Move C and H
        _sequence.Append(_C.DOAnchorPos(_H.anchoredPosition, _animationDuration));
        _sequence.Join(_H.DOAnchorPos(_C.anchoredPosition, _animationDuration));

        _sequence.AppendInterval(_delayBetweenPairs);

        _sequence.Append(_C.DOAnchorPos(_C.anchoredPosition, _animationDuration));
        _sequence.Join(_H.DOAnchorPos(_H.anchoredPosition, _animationDuration));
        #endregion

        _sequence.AppendInterval(Random.Range(0.2f, 0.4f));

        #region Move T and C
        _sequence.Append(_T.DOAnchorPos(_C.anchoredPosition, _animationDuration));
        _sequence.Join(_C.DOAnchorPos(_T.anchoredPosition, _animationDuration));

        _sequence.AppendInterval(_delayBetweenPairs);

        _sequence.Append(_T.DOAnchorPos(_T.anchoredPosition, _animationDuration));
        _sequence.Join(_C.DOAnchorPos(_C.anchoredPosition, _animationDuration));
        #endregion

        _sequence.AppendInterval(_delayBeforeRestart);
        _sequence.SetLoops(-1);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }

    private void Update()
    {
        if (_M.rect.width != _M.sizeDelta.x || _M.rect.height != _M.sizeDelta.y)
        {
            RestartAnimation();
        }
    }

    private void RestartAnimation()
    {
        _sequence.Kill();
        StartAnimation();
    }

}
