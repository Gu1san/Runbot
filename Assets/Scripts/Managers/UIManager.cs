using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Image[] healthBar;
    public GameObject[] powerupIcons;
    public Text coinsCount;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject mainMenu;
    public GameObject inGamePanel;
    public GameObject controlPanel;
    public GameObject settingsPanel;
    public bool isPaused;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Pause();
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(false);
            Unpause();
        }
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Pause();
    }
    public void StartGame()
    {
        GameController.instance.LoadScene();
        mainMenu.SetActive(false);
        inGamePanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Unpause();
        coinsCount.text = GameController.instance.coins.ToString();
    }

    public void ShowControls()
    {
        controlPanel.SetActive(true);   
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void HideControls()
    {
        controlPanel.SetActive(false);
    }

    public void HideSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        GameController.instance.LoadScene();
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Unpause();
        coinsCount.text = GameController.instance.coins.ToString();
        GameController.instance.equipedGun = 0;
    }
    public void MainMenu()
    {
        GameController.instance.MainMenu();
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        inGamePanel.SetActive(false);
        mainMenu.SetActive(true);
        Unpause();
    }
}
