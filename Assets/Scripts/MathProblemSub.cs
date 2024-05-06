using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MathProblemSub : MonoBehaviour
{
    public TextMeshProUGUI firstNumber;
    public TextMeshProUGUI secondNumber;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetScoreText;

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int firstNumberInProblem;
    int secondNumberInProblem;
    int answerOne;
    int answerTwo;
    int displayRandomAnswer;
    int randomAnswerPlacement;
    public int currentAnswer;
    public TextMeshProUGUI rightOrWrong_Text;
    public int score = 0;
    public int targetScore = 10; // Adjust this based on your preference

    private void Start()
    {
        DisplayMathProblem();
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        targetScoreText.text = "Target: " + targetScore;
    }

    public void DisplayMathProblem()
    {
        // Generate random numbers for the subtraction problem
        randomFirstNumber = Random.Range(0, easyMathList.Count + 1);
        randomSecondNumber = Random.Range(0, randomFirstNumber + 1);

        // Assign first and second numbers
        firstNumberInProblem = randomFirstNumber;
        secondNumberInProblem = randomSecondNumber;

        // Calculate answers for subtraction
        answerOne = Mathf.Max(firstNumberInProblem - secondNumberInProblem, 0);
        displayRandomAnswer = Random.Range(0, 2);

        if (displayRandomAnswer == 0)
        {
            answerTwo = Mathf.Max(answerOne + Random.Range(1, 5), 0);
        }
        else
        {
            answerTwo = Mathf.Max(answerOne - Random.Range(1, 5), 0);
        }

        // Display the problem and answers
        firstNumber.text = "" + firstNumberInProblem;
        secondNumber.text = "" + secondNumberInProblem;
        randomAnswerPlacement = Random.Range(0, 2);

        if (randomAnswerPlacement == 0)
        {
            answer1.text = "" + answerOne;
            answer2.text = "" + answerTwo;
            currentAnswer = 0;
        }
        else
        {
            answer1.text = "" + answerTwo;
            answer2.text = "" + answerOne;
            currentAnswer = 1;
        }

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

    void TurnOffText()
    {
        if (rightOrWrong_Text != null)
            rightOrWrong_Text.enabled = false;
        DisplayMathProblem();
    }

    void DisplayVictoryMessage()
    {
        // Load the LevelCompleteScene
        SceneManager.LoadScene("LevelCompleteScene");
    }
}
