using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int currency;
    public int startingCurrency = 90;
    public static int lives;
    public int startingLives = 5;
    public string enemyTag = "Enemy";
    public static int numberOfEnemiesLeft = 0;

    public Text currencyText;
    public Text livesText;

    void Start()
    {
        currency = startingCurrency;
        lives = startingLives;
        //unlock this level
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
    }

    void Update()
    {
        currencyText.text = "Money: " + currency.ToString();
        if (lives <= 0)
        {
            livesText.text = "Game Over";
            SceneController.GameOver();
        }
        else if (numberOfEnemiesLeft <= 0)
        {
            Debug.Log("should go to next level");
            SceneController.NextLevel();
        }
        else
        {
            livesText.text = "Survivors: " + lives.ToString();
        }

    }
}
