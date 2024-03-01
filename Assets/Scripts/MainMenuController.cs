using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Current Highscore: " + highScore;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
