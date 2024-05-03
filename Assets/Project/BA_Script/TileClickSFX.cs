using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileClickSFX : MonoBehaviour
{
    private AudioSource tileClickSFX;

    private void Start()
    {
        tileClickSFX = GameObject.FindGameObjectWithTag("TileClickSFX").GetComponent<AudioSource>();

        Button button = GetComponent<Button>();

        if (button != null && tileClickSFX != null)
        {
            button.onClick.AddListener(PlayAudio);
        }
    }

    private void PlayAudio()
    {
        if (tileClickSFX != null)
        {
            tileClickSFX.Play();
        }
    }
}
