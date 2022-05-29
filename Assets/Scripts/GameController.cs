using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static int totalScoreGeral =0;
    public Text gameWinnerScoreText;
    public GameObject winner;
    public  int totalScoreTela =0;
    public Text scoreText;
    public Text gameOverScoreText;
    
    public static GameController Instance;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        UpdateScoreText();
    }

    // Update is called once per frame
    public void UpdateScoreText()
    {
        scoreText.text = totalScoreGeral.ToString();
        gameOverScoreText.text = totalScoreGeral.ToString();
        gameWinnerScoreText.text = totalScoreGeral.ToString();
    }


    public void ShowGameOver()
    {
        UpdateScoreText();
        gameOver.SetActive(true);
    }
  

    public void RestartGame(string levelName)
    {
        totalScoreGeral = totalScoreGeral - totalScoreTela;
        SceneManager.LoadScene(levelName);
    }
    public void RestartGameZero()
    {
        totalScoreGeral = 0;
        totalScoreTela = 0;
        SceneManager.LoadScene("Level_1");
    }

    public void ShowWinner()
    {
        UpdateScoreText();
        winner.SetActive(true);
    }
}