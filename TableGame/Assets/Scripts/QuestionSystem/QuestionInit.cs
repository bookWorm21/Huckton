using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionInit : MonoBehaviour
{
    [SerializeField] private string _fileNameComplexity1;
    [SerializeField] private string _fileNameComplexity2;
    [SerializeField] private string _fileNameComplexity3;
    [SerializeField] private string _fileNameComplexity4;

    [SerializeField] private TMP_Text _textLabel;
    [SerializeField] private GameObject _panelForQuestion;

    private QuestionsTextLoader _textLoader = new QuestionsTextLoader();

    public int AnswerHardLevel { get; private set; }

    public int Answer { get; private set; }

    private void Start()
    {
        _textLoader.LoadTextFile(_fileNameComplexity1);
    }

    public void ShowText(int answerHardLevel)
    {
        AnswerHardLevel = answerHardLevel;
        Questions questions = _textLoader.GetQuestion(AnswerHardLevel - 1);
        int index = Random.Range(0, questions.QuestionText.Length - 1);

        _panelForQuestion.gameObject.SetActive(true);

        _textLabel.text = questions.QuestionText[index];
        Answer = questions.TrueAnswerNumber[index];
    }

    public void EndOfAnswer()
    {
        _panelForQuestion.gameObject.SetActive(false);
    }
}
