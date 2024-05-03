using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] bool _isOn = true;
    [SerializeField] string _textON = "ON";
    [SerializeField] string _textOff = "OFF";
    [SerializeField] TextMeshProUGUI _buttonText;
    [SerializeField] Color _onColor = new Color(0.149f, 0.670f, 0.129f); //#26AB21
    [SerializeField] Color _offColor = new Color(0.812f, 0.321f, 0.247f); //CF523F

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        SetButtonState(_isOn);
    }

    public void ToggleButtonState()
    {
        _isOn = !_isOn;
        SetButtonState(_isOn);
    }

    private void SetButtonState(bool state)
    {
        if (state)
        {
            _buttonText.text = _textON;
            _image.color = _onColor;
        }
        else
        {
            _buttonText.text = _textOff;
            _image.color = _offColor;
        }
    }
}
