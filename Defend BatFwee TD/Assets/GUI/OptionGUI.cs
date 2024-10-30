using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bgmVolTxt;
    [SerializeField] private TextMeshProUGUI sfxVolTxt;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private AudioManager audioManager;
    private GameManager gameManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        SetVisual();
    }

    public void SetBGMSlider(float val)
    {
        if (audioManager != null)
        {
            audioManager.SetBGMVol(val);
        }
        else
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    public void SetSFXSlider(float val)
    {
        if (audioManager != null)
        {
            audioManager.SetSFXVol(val);
        }
        else
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    public void MuteToggle(bool val)
    {
        if (audioManager != null)
        {
            audioManager.MuteAudio(val);
        }
        else
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    public void CloseOption()
    {
        gameObject.SetActive(false);
        if (gameManager != null)
        {
            gameManager.isOpeningOption = false;
        }
        else
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    public void BackToMenu()
    {
        if (gameManager != null)
        {
            gameManager.isOpeningOption = false;
        }
        else
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        SceneManager.LoadScene(0);
    }

    private void SetVisual()
    {
        bgmVolTxt.text = (audioManager.Bgm.volume * 100).ToString();
        sfxVolTxt.text = (audioManager.TurretSound.volume * 100).ToString();

        bgmSlider.value = audioManager.Bgm.volume;
        sfxSlider.value = audioManager.TurretSound.volume;
    }
}
