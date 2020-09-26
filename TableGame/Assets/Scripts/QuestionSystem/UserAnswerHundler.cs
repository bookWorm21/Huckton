using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAnswerHundler : MonoBehaviour
{
    [SerializeField] QuestionInit _questionInit;
    [SerializeField] QueueSwitch _switcher;

    [SerializeField] private int _pointsForOnComplexity;

    private int _trueAnswerNumber;
    private int _answerNumber;

    public void SetAnswerNumber(int value)
    {
        int points = 0;
        _trueAnswerNumber = _questionInit.Answer;
        _answerNumber = value;

        if(_trueAnswerNumber == _answerNumber)
        {
            points = _pointsForOnComplexity * _questionInit.AnswerHardLevel;
        }

        _switcher.NextPlayerInQueue(points);
    }
}
