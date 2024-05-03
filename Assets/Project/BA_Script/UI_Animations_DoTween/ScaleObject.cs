using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleObject : MonoBehaviour
{
    [SerializeField] GameObject[] _objectsToAnimate;
    [SerializeField] float _animationDuration = 1f;
    [SerializeField] Ease _easeType = Ease.OutBounce;

    public void AnimateScaling()
    {
        foreach (GameObject obj in _objectsToAnimate)
        {
            obj.SetActive(true);
            obj.transform.localScale = Vector3.zero;
            obj.transform.DOScale(Vector3.one, _animationDuration).SetEase(_easeType);
        }
    }

    public void SetActiveToFalse()
    {
        foreach (GameObject obj in _objectsToAnimate)
        {
            obj.transform.DOScale(Vector3.one, _animationDuration).SetEase(_easeType)
                       .OnComplete(() =>
                       {
                           obj.SetActive(false);
                       });
        }
    }
}
