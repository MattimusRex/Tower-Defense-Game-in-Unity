using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public void StartFirstLevel()
    {
        SceneManager.LoadScene("firstLevel");
    }

    public void StartSecondLevel()
    {
        SceneManager.LoadScene("secondLevel");
    }

    public void StartThirdLevel()
    {
        SceneManager.LoadScene("thirdLevel");
    }

    public void StartFourthLevel()
    {
        SceneManager.LoadScene("fourthLevel");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public static void YouWin()
    {
        SceneManager.LoadScene("You Win Scene");
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
