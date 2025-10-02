using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text leftScoreText;
    public TMP_Text rightScoreText;

    private int leftScore = 0;
    private int rightScore = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddPoint(bool leftPlayer)
    {
        if (leftPlayer)
            leftScore++;
        else
            rightScore++;

        UpdateUI();
    }

    void UpdateUI()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }
}
