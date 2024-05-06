using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberComparisonGame : MonoBehaviour
{
    public TextMeshProUGUI firstNumber;
    public TextMeshProUGUI secondNumber;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetScoreText;
    public TextMeshProUGUI rightOrWrong_Text;

    public List<int> easyMathList = new List<int>();

    private int randomFirstNumber;
    private int randomSecondNumber;

    private int firstNumberInProblem;
    private int secondNumberInProblem;
    private int answerOne;
    private int answerTwo;
    private int displayRandomAnswer;
    private int randomAnswerPlacement;
    private int currentAnswer;

    private int score = 0;
    private int targetScore = 10; // Adjust this based on your preference

    private void Start()
    {
        DisplayMathProblem();
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        targetScoreText.text = "Target: " + targetScore;
    }

    public void DisplayMathProblem()
    {
        // Generate random numbers for the first and second numbers
        randomFirstNumber = Random.Range(0, easyMathList.Count + 1);
        randomSecondNumber = Random.Range(0, easyMathList.Count + 1);

        // Assign the first and second numbers
        firstNumberInProblem = randomFirstNumber;
        secondNumberInProblem = randomSecondNumber;

        // Compare if firstNumber is greater than secondNumber
        bool isGreaterThan = firstNumberInProblem > secondNumberInProblem;

        // Assign answers based on the comparison
        answerOne = isGreaterThan ? 1 : 0;  // True
        answerTwo = isGreaterThan ? 0 : 1;  // False

        // Display the numbers and fixed answers
        firstNumber.text = "" + firstNumberInProblem;
        secondNumber.text = "" + secondNumberInProblem;

        // Always set answer1 as "True" and answer2 as "False"
        answer1.text = "True";
        answer2.text = "False";

        // Assign the correct answer to the True or False button based on the comparison
        currentAnswer = isGreaterThan ? 0 : 1;

        UpdateUI();
    }

    public void ButtonAnswer(int selectedAnswer)
    {
        if (currentAnswer == selectedAnswer)
        {
            score++;

            if (score >= targetScore)
            {
                // Player has completed the level
                DisplayVictoryMessage();
                return;
            }

            // Rest of the correct answer logic
            rightOrWrong_Text.enabled = true;
            rightOrWrong_Text.color = Color.green;
            rightOrWrong_Text.text = "Correct";
        }
        else
        {
            rightOrWrong_Text.enabled = true;
            rightOrWrong_Text.color = Color.red;
            rightOrWrong_Text.text = "Try Again";
        }

        Invoke("TurnOffText", 1);
    }

    public void ButtonAnswer1()
    {
        ButtonAnswer(0);
    }

    public void ButtonAnswer2()
    {
        ButtonAnswer(1);
    }

    private void TurnOffText()
    {
        if (rightOrWrong_Text != null)
            rightOrWrong_Text.enabled = false;
        DisplayMathProblem();
    }

    private void DisplayVictoryMessage()
    {
        // Load the LevelCompleteScene
        SceneManager.LoadScene("LevelCompleteScene");
    }
}
