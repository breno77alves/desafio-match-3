using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class MoveTransition : MonoBehaviour
{
    [SerializeField] GameObject[] _items;
    [SerializeField] GameObject _blocks;
    [SerializeField] string _sceneName;

    [SerializeField] float _fadeTime = 0.1f;
    #region Unity

    private void Start()
    {
        _blocks.SetActive(true);
        RemoveTransitionImage();
    }
    #endregion

    public void AddTransitionImage(string sceneName)
    {
        _sceneName = sceneName;
        _blocks.SetActive(true);
        StartCoroutine(AnimateItems(true));
    }

    public void RemoveTransitionImage()
    {
        StartCoroutine(AnimateItems(false));
    }

    private IEnumerator AnimateItems(bool fadeIn)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (fadeIn)
            {
                _items[i].transform.localScale = Vector3.zero;
            }

            float delay = 0.05f;

            yield return new WaitForSeconds(delay);

            if (fadeIn)
            {
                _items[i].transform.DOScale(1f, _fadeTime)
                    .SetEase(Ease.OutBounce);
            }
            else
            {
                _items[i].transform.DOScale(0f, _fadeTime)
                    .SetDelay(1f)
                    .OnComplete(() =>
                    {
                        if (i == _items.Length - 1)
                        {
                            _blocks.SetActive(false);
                        }
                    });
            }
        }

        if (fadeIn)
        {
            yield return new WaitForSeconds(_fadeTime);
            OpenSceneAsync();
        }
    }


    public void OpenSceneAsync()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnDestroy()
    {
        CleanUpTweens();
    }

    private void CleanUpTweens()
    {
        foreach (GameObject items in _items)
        {
            DOTween.Kill(items);
        }
    }

}
