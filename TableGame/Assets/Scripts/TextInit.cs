using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInit : MonoBehaviour
{
    [SerializeField] private string _fileNameComplexity1;
    [SerializeField] private string _fileNameComplexity2;
    [SerializeField] private string _fileNameComplexity3;
    [SerializeField] private string _fileNameComplexity4;

    [SerializeField] private int _answerHardLevel;
    [SerializeField] private TMP_Text _textLabel;

    private QuestionsTextLoader _textLoader = new QuestionsTextLoader();

    private void Start()
    {
        _textLoader.LoadTextFile(_fileNameComplexity1);
    }

    public void ShowText()
    {
        Questions questions = _textLoader.GetQuestion(_answerHardLevel - 1);
        int index = Random.Range(0, questions.QuestionText.Length - 1);
        _textLabel.text = questions.QuestionText[index];
    }
}
