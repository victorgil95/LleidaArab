using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialScreen : MonoBehaviour
{
    public Button initialScreenToLevelSelection;
    public Button initialScreenInstructions;

    private void Awake()
    {
        initialScreenToLevelSelection.onClick.AddListener(OnClickInitialScreenToLevelSelection);
        initialScreenInstructions.onClick.AddListener(OnClickInitialScreenInstructions);
    }

    void OnClickInitialScreenToLevelSelection()
    {
        LAGameManager.Instance.BackToLevelSelection();
    }

    void OnClickInitialScreenInstructions()
    {
        LAGameManager.Instance.OnClickInstructions();
    }
}
