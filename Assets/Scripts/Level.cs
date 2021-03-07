using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int ID;
    public string levelName;
    public int dirkams;

    public bool completed = false;
    public bool isMandatory = false;
    public bool locked = true;

    public List<Level> levelsUnlocked;

    public Button completeButton;
    public List<Answer> answers;
    
    [System.Serializable]
    public class Answer
    {
        public InputField answer;
        public Text answerFeedback;
        public string answerCheck;

        public bool CheckAnswer()
        {
            return this.answer.text.Equals(this.answerCheck);
        }
    }

    private void Awake()
    {
        if (completeButton)
            completeButton.onClick.AddListener(OnClickComplete);
    }

    void OnClickComplete()
    {
        LAGameManager.Instance.RequestCompleteLevel(this);
    }

}
