using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public List<Level> levels;
    public int currentLevel = 1;

    public Button backToLevelSelection;

    private void Awake()
    {
        backToLevelSelection.onClick.AddListener(OnClickBackToLevelSelection);
    }


    void OnClickBackToLevelSelection()
    {
         LAGameManager.Instance.BackToLevelSelection();
    }
}
