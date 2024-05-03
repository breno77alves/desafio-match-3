using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _pointsText;
    [SerializeField] TextMeshProUGUI _feedBackMessage;
    [SerializeField] float _scaleDuration = 0.2f;
    [SerializeField] float _delayBetweenAnimations = 0.1f;

    private Vector2 _initialPosition;
    private int _currentPoints;

    private void Start()
    {
        RectTransform _feedBackRectTransform = _feedBackMessage.GetComponent<RectTransform>();

        _initialPosition = _feedBackRectTransform.anchoredPosition;
    }

    public void AddPoints()
    {
        int points = UnityEngine.Random.Range(200, 400);
        AnimatePoints(_currentPoints + points);

        if (points >= 360)
        {
            _feedBackMessage.text = "INCREDIBLE!";
        }
        else if (points >= 330)
        {
            _feedBackMessage.text = "NOOICE";
        }
        else
        {
            _feedBackMessage.text = "GOOD";
        }

        AnimateFeedBack();
    }

    private void AnimatePoints(int newPoints)
    {
        Sequence _updatePointsSequence = DOTween.Sequence();

        _updatePointsSequence.Append(_pointsText.transform.DOScale(1.2f, _scaleDuration));
        _updatePointsSequence.AppendCallback(() =>
        {
            _currentPoints = newPoints;
            _pointsText.text = _currentPoints.ToString();
        });
        _updatePointsSequence.AppendInterval(_delayBetweenAnimations);
        _updatePointsSequence.Append(_pointsText.transform.DOScale(1.0f, _scaleDuration));

        _updatePointsSequence.Play();
    }

    private void AnimateFeedBack()
    {
        Sequence _feedBackSequence = DOTween.Sequence();

        _feedBackSequence.Append(_feedBackMessage.rectTransform.DOScale(1f, _scaleDuration).From(0f));
        _feedBackSequence.Join(_feedBackMessage.rectTransform.DOAnchorPosY(_initialPosition.y + 100, _scaleDuration));
        _feedBackSequence.Join(_feedBackMessage.DOFade(1f, _scaleDuration).From(0f));

        _feedBackSequence.AppendInterval(2f);

        _feedBackSequence.Append(_feedBackMessage.rectTransform.DOScale(0f, _scaleDuration));
        _feedBackSequence.Join(_feedBackMessage.rectTransform.DOAnchorPosY(_initialPosition.y - 100, _scaleDuration));
        _feedBackSequence.Join(_feedBackMessage.DOFade(0f, _scaleDuration));

        _feedBackSequence.Play();
    }
}
