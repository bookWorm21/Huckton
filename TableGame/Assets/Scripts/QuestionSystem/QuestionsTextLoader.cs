using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsTextLoader
{
    private string[] _templateStringArrray;

    private List<Questions> _questions = new List<Questions>();

    public Questions GetQuestion(int level)
    {
        if(level >= 0 && level <= (_questions.Count - 1))
        {
            return _questions[level];
        }

        return null;
    }

    public void LoadTextFile(string fileName)
    {
        var questionText = Resources.Load<TextAsset>(fileName).ToString();
        
        _templateStringArrray = questionText.Split(';');
        StringHundler(_templateStringArrray);
    }

    private void StringHundler(string[] start)
    {
        List<int> answers = new List<int>();
        List<string> questions = new List<string>();
        string current = "";

        for (int i = 0; i < start.Length; i++)
        {
            for (int j = 0; j < start[i].Length; j++)
            {
                if ((j == start[i].Length - 3) == false)
                {
                    current += start[i][j];
                }
                else
                {
                    answers.Add(System.Convert.ToInt32(start[i][j]));
                }
            }
            questions.Add(current);

            current = "";
        }

        _questions.Add(new Questions(questions.ToArray(), answers.ToArray()));
    }
}

public class Questions
{
    public string[] QuestionText;
    public int[] TrueAnswerNumber;

    public Questions(string[] questions, int[] answers)
    {
        QuestionText = questions;
        TrueAnswerNumber = answers;
    }
}
