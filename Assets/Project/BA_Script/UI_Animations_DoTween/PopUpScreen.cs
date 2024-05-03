using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUpScreen : MonoBehaviour
{
    [SerializeField] GameObject _objectToDeactivate;

    public void Open()
    {
        transform.localScale = Vector3.zero;

        transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
    }

    public void Close()
    {
        transform.DOScale(Vector2.zero, 0.5f).SetEase(Ease.InBack).OnComplete(DeactivateGameObject);
    }

    private void DeactivateGameObject()
    {
        if (_objectToDeactivate != null)
        {
            _objectToDeactivate.SetActive(false);
        }
    }
}
