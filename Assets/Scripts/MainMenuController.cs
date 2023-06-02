using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // Add this line here

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Current Highscore: " + highScore;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("SampleScene"); // replace "GameScene" with the name of your game scene
        }
    }
}
