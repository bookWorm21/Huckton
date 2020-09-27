using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserAnswerHundler : MonoBehaviour
{
    [SerializeField] QuestionInit _questionInit;
    [SerializeField] QueueSwitch _switcher;

    [SerializeField] private InputField _inputField;

    [SerializeField] private int _pointsForOnComplexity;

    private int _trueAnswerNumber;
    private int _answerNumber;

    public void SetAnswerNumber(string value)
    {
        string answer = value;
        int points = 0;
        int number = 0;

        if(_questionInit.AnswerHardLevel == 2)
        {
            answer = _inputField.text;
        }

        try
        {
            number = int.Parse(answer);
        }
        catch
        {

        }

        _trueAnswerNumber = _questionInit.Answer;
        _answerNumber = number;

        if (_trueAnswerNumber == _answerNumber)
        {
            points = _pointsForOnComplexity * _questionInit.AnswerHardLevel;
        }

        _inputField.text = "";
        _switcher.NextPlayerInQueue(points);
    }
}
