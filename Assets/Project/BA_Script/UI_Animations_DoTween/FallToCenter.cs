using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FallToCenter : MonoBehaviour
{
    [SerializeField] GameObject _objectToDeactivate;
    [SerializeField] float _animationDuration = 1f;
    [SerializeField] Ease _easeType = Ease.OutBounce;
    
    private ScaleObject _scaleAnimationScript;
    private RectTransform _rectTransform;
    private Vector3 _initialPosition;

    private void Awake()
    {
        _scaleAnimationScript = GetComponent<ScaleObject>();

        _rectTransform = GetComponent<RectTransform>();
        _initialPosition = _rectTransform.anchoredPosition;
    }

    public void Open()
    {
        _rectTransform.anchoredPosition = new Vector2(_initialPosition.x, Screen.height + 1500);

        _rectTransform.DOAnchorPosY(_initialPosition.y, _animationDuration).SetEase(_easeType)
            .OnComplete(() => OnOpenAnimationComplete());
    }

    public void Close()
    {
        _rectTransform.DOAnchorPosY(Screen.height + 1500, _animationDuration).SetEase(_easeType).OnComplete(DeactivateGameObject);
    }

    private void DeactivateGameObject()
    {
        if (_objectToDeactivate != null)
        {
            _objectToDeactivate.SetActive(false);
        }
        _scaleAnimationScript.SetActiveToFalse();
    }

    private void OnOpenAnimationComplete()
    {
        _scaleAnimationScript.AnimateScaling();
    }
}
