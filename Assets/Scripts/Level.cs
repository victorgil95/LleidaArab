using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public int ID;
    public string levelName;
    public bool completed = false;
    public int dirkams;
    public bool locked = true;
    public List<Level> UnlockableLevels;
    public InputField answer;
    public Text answerFeedback;

    public Button completeButton;

    private void Awake()
    {
        completeButton.onClick.AddListener(OnClickComplete);
    }

    void OnClickComplete()
    {
        LAGameManager.Instance.RequestCompleteLevel(this);
    }

    


}
