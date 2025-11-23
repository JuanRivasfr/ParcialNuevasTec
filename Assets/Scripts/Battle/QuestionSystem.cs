using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
    public int damageOnCorrect;
    public int energyCostOnWrong;
}

public class QuestionSystem : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private TextMeshProUGUI[] answerTexts;

    [Header("Questions")]
    [SerializeField] private Question[] questions;

    private Question currentQuestion;
    private Action<int> onAnswerSelected;

    private void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < answerButtons.Length && i < answerTexts.Length; i++)
        {
            int index = i; // Capture for closure
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }
    }

    public void LoadQuestion(Question question, Action<int> callback)
    {
        currentQuestion = question;
        onAnswerSelected = callback;

        if (questionText != null && question != null)
        {
            questionText.text = question.questionText;
        }

        for (int i = 0; i < answerButtons.Length && i < answerTexts.Length; i++)
        {
            if (i < question.answers.Length)
            {
                answerTexts[i].text = question.answers[i];
                answerButtons[i].gameObject.SetActive(true);
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnAnswerSelected(int answerIndex)
    {
        if (currentQuestion == null) return;

        bool isCorrect = answerIndex == currentQuestion.correctAnswerIndex;
        onAnswerSelected?.Invoke(answerIndex);
    }

    public Question GetRandomQuestion()
    {
        if (questions == null || questions.Length == 0) return null;
        return questions[UnityEngine.Random.Range(0, questions.Length)];
    }
}
