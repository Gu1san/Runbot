using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    int level;
    public int playerHealth;
    public int coins;
    public int totalHP;
    public int equipedGun;

    [Header("Powerups")]
    public bool buffFireRate;
    public bool shieldAvaliable;
    public bool doubleGun;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        playerHealth = totalHP;
        coins = 0;
    }

    public void OnHit()
    {
        playerHealth--;
        UIManager.instance.healthBar[playerHealth+1].enabled = false;
        UIManager.instance.healthBar[playerHealth].enabled = true;
        if (playerHealth == 0)
        {
            GameOver();
        }
    }

    public void OnHeal(int healValue)
    {
        if(playerHealth < totalHP)
        {
            playerHealth += healValue;
            UIManager.instance.healthBar[playerHealth - healValue].enabled = false;
            if (playerHealth > totalHP)
            {
                UIManager.instance.healthBar[totalHP].enabled = true;
                playerHealth = totalHP;
            }
            else
            {
                UIManager.instance.healthBar[playerHealth].enabled = true;
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        equipedGun = 0;
    }

    public void GameOver()
    {
        UIManager.instance.ShowGameOver();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level4");
        level = 1;
        UIManager.instance.healthBar[playerHealth].enabled = false;
        playerHealth = totalHP;
        UIManager.instance.healthBar[playerHealth].enabled = true;
        coins = 0;
        ResetEquipment();
    }

    public void NextLevel()
    {
        level++;
        SceneManager.LoadScene(level);
        UIManager.instance.pausePanel.SetActive(false);
        UIManager.instance.Unpause();
    }

    void ResetEquipment()
    {
        buffFireRate = false;
        shieldAvaliable = false;
        doubleGun = false;
        foreach(GameObject icon in UIManager.instance.powerupIcons)
        {
            icon.SetActive(false);
        }
    }
}
