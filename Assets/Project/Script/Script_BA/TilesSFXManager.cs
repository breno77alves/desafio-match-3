using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TilesSFXManager : MonoBehaviour
{
    [SerializeField] AudioSource _sfx;

    private float _defaultPitch = 0.8f;

    public void PlayLargeMatchSFX()
    {
        if (_sfx != null)
        {
            int playCount = Random.Range(3, 5);

            for (int i = 0; i < playCount; i++)
            {
                float randomPitch = Random.Range(0.6f, 1f);
                float stereoPan = (i % 2 == 0) ? -1f : 1f;

                DOVirtual.DelayedCall(i * 0.2f, () =>
                {
                    _sfx.pitch = randomPitch;
                    _sfx.panStereo = stereoPan;
                    _sfx.Play();
                });
            }
            _sfx.pitch = _defaultPitch;
            _sfx.panStereo = 0f;
        }
    }

    public void PlaySmallMatchSFX()
    {
        if (_sfx != null)
        {
            _sfx.pitch = _defaultPitch;
            _sfx.panStereo = 0f;
            _sfx.Play();
        }
    }
}
