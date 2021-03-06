using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleAnswers : MonoBehaviour
{
    public Level level;
    public List<string> answers;
    public Button button;
    public InputField inputfield;
    public Text feedbackText;
    public Text nRemainingAnswers;

    private List<string> remainingAnswers = new List<string>();

    private void Awake()
    {
        button.onClick.AddListener(OnClickCheckAnswer);
        foreach (string answer in answers)
        {
            remainingAnswers.Add(answer);
        }
        UpdateReaminingAnswers();
    }

    private void OnClickCheckAnswer()
    {
        string answer = inputfield.text;
        if (remainingAnswers.Contains(answer))
        {
            remainingAnswers.Remove(answer);
            UpdateReaminingAnswers();
            feedbackText.text = "Correcte !!!";
            inputfield.text = "";
            if (remainingAnswers.Count == 0)
            {
                LAGameManager.Instance.RequestCompleteLevel(level);
                button.interactable = false;
            }
        }
        else if(answers.Contains(answer) && !remainingAnswers.Contains(answer))
        {
            feedbackText.text = "Repetida !";
        }
        else
        {
            feedbackText.text = "Resposta incorrecta...";
        }
    }

    private void UpdateReaminingAnswers()
    {
        nRemainingAnswers.text = "Restants: " + remainingAnswers.Count.ToString();
    }
    
}
