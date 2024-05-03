using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToAnimator : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private string _booleanInMainPage = "InMainPage";
    private string _booleanInShopPage = "InShopPage";

    public void SetInMainPage(bool _InMainPage)
    {
        _animator.SetBool(_booleanInMainPage, _InMainPage);
    }

    public void SetInShopPage(bool _InShopPage)
    {
        _animator.SetBool(_booleanInShopPage, _InShopPage);
    }

}
