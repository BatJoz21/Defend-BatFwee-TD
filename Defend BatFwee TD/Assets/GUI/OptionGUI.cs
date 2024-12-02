using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionGUI : MonoBehaviour
{
    [SerializeField] private GameObject optionCanvas;
    [SerializeField] private TextMeshProUGUI bgmVolTxt;
    [SerializeField] private TextMeshProUGUI sfxVolTxt;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private static OptionGUI instance;
    private AudioManager audioManager;
    private LevelManager levelManager;

    void Awake()
    {
        ManageOption();
        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
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

    public void OpenOption()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            optionCanvas.SetActive(true);
        }
        else
        {
            if (levelManager != null)
            {
                optionCanvas.SetActive(true);
                levelManager.isOpeningOption = true;
            }
            else
            {
                levelManager = FindObjectOfType<LevelManager>();
            }
        }
    }

    public void CloseOption()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            optionCanvas.SetActive(false);
        }
        else
        {
            if (levelManager != null)
            {
                optionCanvas.SetActive(false);
                levelManager.isOpeningOption = false;
            }
            else
            {
                levelManager = FindObjectOfType<LevelManager>();
            }
        }
    }

    public void BackToMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            optionCanvas.SetActive(false);
            SceneManager.LoadScene(0);
        }
        else
        {
            if (levelManager != null)
            {
                levelManager.isOpeningOption = false;
                optionCanvas.SetActive(false);
                SceneManager.LoadScene(0);
            }
            else
            {
                levelManager = FindObjectOfType<LevelManager>();
            }
        }
    }

    private void SetVisual()
    {
        bgmVolTxt.text = (audioManager.Bgm.volume * 100).ToString();
        sfxVolTxt.text = (audioManager.TurretSound.volume * 100).ToString();

        bgmSlider.value = audioManager.Bgm.volume;
        sfxSlider.value = audioManager.TurretSound.volume;
    }

    private void ManageOption()
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
