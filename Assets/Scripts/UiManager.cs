using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource looseSound;
    [SerializeField] private AudioSource winSound;
    [Header("Panels and Objects")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject[] menuButtons;
    [SerializeField] private Text timer;
    [Header("Settings")]
    [SerializeField] private bool isTimerNeeded;
    [SerializeField] private float timerTime;
    [SerializeField] private int levelToRestart;
    [SerializeField] private int NextLevel;
    private bool isTimeOut;
    private int count = 0;

    private void Start()
    {
        menuPanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        isTimeOut = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (timer != null & isTimerNeeded)
        {
            Timer();
            timer.text = Mathf.Round(timerTime).ToString();
        }
        if (isTimeOut & count == 0) 
        {
            looseSound.Play();
            Time.timeScale = 0f;
            losePanel.SetActive(true);
            count++;
        }
    }

    public void OnAppCloseClick()
    {
        Application.Quit();
    }

    public void OnNextLevelClick()
    {
        SceneManager.LoadScene(NextLevel);
    }

    public void FinishReached()
    {
        AdsCore.ShowAdsVideo("Interstitial_Android");
        winSound.Play();
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnBackClick()
    {
        menuButtons[0].SetActive(true);
        menuButtons[1].SetActive(true);
        menuButtons[2].SetActive(false);
        menuButtons[3].SetActive(false);
        if (menuButtons[4] != null)
        {
            menuButtons[4].SetActive(true);
        }
    }

    public void OnCreatorsClick()
    {
        menuButtons[0].SetActive(false);
        menuButtons[1].SetActive(false);
        menuButtons[2].SetActive(true);
        menuButtons[3].SetActive(true);
        if (menuButtons[4] != null)
        {
            menuButtons[4].SetActive(false);
        }
    }

    public void OnContinueClick()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(levelToRestart);
    }

    public void OnQuitClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnMenuClick()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Timer()
    {
        if (timerTime >= 0)
        {
            timerTime -= Time.deltaTime;
        }
        else isTimeOut = true;
    }
}
