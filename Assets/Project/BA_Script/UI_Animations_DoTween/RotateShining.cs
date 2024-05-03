using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RotateShining : MonoBehaviour
{
    [SerializeField] RectTransform _object1RectTransform;
    [SerializeField] float _rotationSpeed = 50f;
    [SerializeField] float _durationFade = 0.4f;

    void FixedUpdate()
    {
        if (_object1RectTransform != null)
        {
        _object1RectTransform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        }
    }

    public void FadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.DOFade(0f, _durationFade).OnComplete(() => canvasGroup.gameObject.SetActive(false));
        _object1RectTransform.DOScale(0f, _durationFade);
    }
}
