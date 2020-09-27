using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionInit : MonoBehaviour
{
    [SerializeField] private string _fileNameComplexity1;
    [SerializeField] private string _fileNameComplexity2;
    [SerializeField] private string _fileNameComplexity3;
    [SerializeField] private string _fileNameComplexity4;

    [SerializeField] private TMP_Text _textLabel;
    [SerializeField] private TMP_Text _textLabelForInputQuestion;
    [SerializeField] private GameObject _panelForQuestion;
    [SerializeField] private GameObject _panelForInput;

    private QuestionsTextLoader _textLoader = new QuestionsTextLoader();

    private Random r = new Random();
    private string[] Funx = new string[] { "+", "-", "*", "/" };

    private string Funx1, Funx2, Funx3;

    private float _result;

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

    public void ShowText()
    {
        AnswerHardLevel = 2;
        _panelForInput.gameObject.SetActive(true);
        Generate();
    }

    public void EndOfAnswer()
    {
        _panelForQuestion.gameObject.SetActive(false);
        _panelForInput.gameObject.SetActive(false);
    }

    private void Generate()
    {
        int a, b, c, d;

        int operationNum = Random.Range(1, 4);
        if (operationNum == 1)
        {
            a = Random.Range(1, 50);
            b = Random.Range(1, 50);

            Funx1 = Funx[Random.Range(0, 4)];
            _textLabelForInputQuestion.text = System.Convert.ToString(a) + " " + Funx1 + " " + System.Convert.ToString(b);
            Answer = System.Convert.ToInt32(FunxResult1(a, b));
        }
        if (operationNum == 2)
        {
            a = Random.Range(1, 50);
            b = Random.Range(1, 50);
            c = Random.Range(1, 50);

            Funx1 = Funx[Random.Range(0, 4)];
            Funx2 = Funx[Random.Range(0, 4)];
            _textLabelForInputQuestion.text = "(" + System.Convert.ToString(a) + " " + Funx1 + " " + System.Convert.ToString(b) + ")" + " " + Funx2 + " " + System.Convert.ToString(c);
            Answer = System.Convert.ToInt32(FunxResult2(FunxResult1(a, b), c));

        }
        if (operationNum == 3)
        {
            a = Random.Range(1, 50);
            b = Random.Range(1, 50);
            c = Random.Range(1, 50);
            d = Random.Range(1, 50);
            Funx1 = Funx[Random.Range(0, 4)];
            Funx2 = Funx[Random.Range(0, 4)];
            Funx3 = Funx[Random.Range(0, 4)];

            _textLabelForInputQuestion.text = "(" + "(" + System.Convert.ToString(a) + " " + Funx1 + " " + System.Convert.ToString(b) + ")" + " " + Funx2 + " " + System.Convert.ToString(c) + ")" + " " + Funx3 + " " + System.Convert.ToString(d);
            Answer = System.Convert.ToInt32(FunxResult3(FunxResult2(FunxResult1(a, b), c), d));
        }
    }

    private float FunxResult1(float a, float b)
    {
        if (Funx1 == Funx[0])
        {
            _result = a + b;
        }
        if (Funx1 == Funx[1])
        {
            _result = a - b;
        }
        if (Funx1 == Funx[2])
        {
            _result = a * b;
        }
        if (Funx1 == Funx[3])
        {
            _result = a / b;
        }
        return _result;

    }
    private float FunxResult2(float a, float b)
    {
        if (Funx2 == Funx[0])
        {
            _result = a + b;
        }
        if (Funx2 == Funx[1])
        {
            _result = a - b;
        }
        if (Funx2 == Funx[2])
        {
            _result = a * b;
        }
        if (Funx2 == Funx[3])
        {
            _result = a / b;
        }
        return _result;
    }

    private float FunxResult3(float a, float b)
    {
        if (Funx3 == Funx[0])
        {
            _result = a + b;
        }
        if (Funx3 == Funx[1])
        {
            _result = a - b;
        }
        if (Funx3 == Funx[2])
        {
            _result = a * b;
        }
        if (Funx3 == Funx[3])
        {
            _result = a / b;
        }
        return _result;
    }
}
