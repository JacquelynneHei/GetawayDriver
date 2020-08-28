using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Singleton
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    public ScoreManager score;
    public SceneChange sceneChange;

    [Header("UI Elements")]
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;

    private int coins;

    private void Start()
    {
        coins = 0;
    }

    private void Update()
    {
        UpdateUI();
        AdjustScore();
    }

    void UpdateUI()
    {
        scoreText.text = ((int)score.score).ToString();
        multiplierText.text = "x" + score.multiplier.ToString();
        coinsText.text = score.coins.ToString();
    }

    void AdjustScore()
    {
        score.score += score.scoreBase * score.multiplier * Time.deltaTime;
    }

    public void GameOver()
    {
        //do game over stuff
        sceneChange.GameOver();
    }

    public void AddCoin()
    {
        coins++;
        score.coins = coins;
    }
}
