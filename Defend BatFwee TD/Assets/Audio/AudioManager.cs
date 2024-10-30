using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource turretSound;
    [SerializeField] private AudioSource explosionSound;

    private static AudioManager instance;

    public AudioSource Bgm { get => bgm; }
    public AudioSource TurretSound { get => turretSound; }
    public AudioSource ExplosionSound { get => explosionSound; }

    void Awake()
    {
        ManageAudioManager();
    }

    public void PlaySFX(int val)
    {
        switch (val)
        {
            case 0:
                turretSound.Play(); break;
            case 1:
                explosionSound.Play(); break;
            default:
                break;
        }
    }

    public void SetBGMVol(float val)
    {
        if (val >= 0 || val <= 1)
        {
            bgm.volume = val;
        }
    }

    public void SetSFXVol(float val)
    {
        if (val >= 0 || val <= 1)
        {
            turretSound.volume = val;
            explosionSound.volume = val;
        }
    }

    public void MuteAudio(bool val)
    {
        bgm.mute = val;
        turretSound.mute = val;
        explosionSound.mute = val;
    }

    private void ManageAudioManager()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
